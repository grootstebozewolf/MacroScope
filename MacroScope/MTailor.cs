using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace MacroScope
{
    /// <summary>
    /// Common transformations for <see cref="MSqlServerTailor"/>
    /// and <see cref="MAccessTailor"/>.
    /// </summary>
    public abstract class MTailor : TracingVisitor
    {
        #region Fields

        private Namer m_namer;

        private readonly ExpressionOperator m_modOp;

        #endregion

        #region Constructor

        public MTailor(ExpressionOperator modOp)
        {
            if (modOp == null)
            {
                throw new ArgumentNullException("modOp");
            }

            m_modOp = modOp;
        }

        #endregion

        #region Properties

        public Namer Namer
        {
            get
            {
                if (m_namer == null)
                {
                    m_namer = new Namer('@');
                }

                return m_namer;
            }

            set
            {
                if (value == null)
                {
                    throw new ArgumentNullException("value");
                }

                m_namer = value;
            }
        }

        #endregion

        #region IVisitor Members

        public override void PerformAfter(FunctionCall node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            base.PerformAfter(node);

            if (TailorUtil.MOD.Equals(node.Name.ToLowerInvariant()))
            {
                ReplaceTerm(node, MakeModCall(node));
            }
        }

        public override void PerformBefore(Interval node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            ReplaceIntervals(null);

            base.PerformBefore(node);
        }

        public override void Perform(Identifier node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            base.Perform(node);

            if (TailorUtil.IsRownum(node))
            {
                int limit = 0;

                QueryExpression query = GetAncestor<QueryExpression>(null, null);
                if (query != null)
                {
                    Expression relational = GetExpressionAncestor(null, query);
                    if (relational != null)
                    {
                        limit = TailorUtil.GetRownumExpressionLimit(relational);
                        if (limit > 0)
                        {
                            bool matched = false;

                            Expression logical = GetExpressionAncestor(relational, query);
                            if (logical == null)
                            {
                                if (query.Where == relational)
                                {
                                    query.Where = null;
                                    matched = true;
                                }
                            }
                            else
                            {
                                if (logical.Operator == ExpressionOperator.And)
                                {
                                    if (relational == logical.Left)
                                    {
                                        logical.Operator = null;
                                        logical.Left = null;
                                        matched = true;
                                    }
                                    else if (relational == logical.Right)
                                    {
                                        logical.Operator = null;
                                        logical.Right = null;
                                        matched = true;
                                    }
                                }
                            }

                            if (matched)
                            {
                                SetTop(query, limit);
                            }
                            else
                            {
                                limit = -1;
                            }
                        }
                    }
                }

                if (limit <= 0)
                {
                    throw new InvalidOperationException(
                        "MS engines do not have ROWNUM.");
                }
            }
        }

        public override void Perform(Placeholder node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            base.Perform(node);

            Namer.Perform(this, node);
        }

        public override void PerformBefore(QueryExpression node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            base.PerformBefore(node);

            if (node.Where == null)
            {
                AliasedItem from = node.From;
                if ((from != null) && (from.Alias == null) && !from.HasNext)
                {
                    Table singleTable = from.Item as Table;
                    if ((singleTable != null) && (singleTable.Alias == null) &&
                        (singleTable.JoinCondition == null) &&
                        (singleTable.JoinType == null) && !singleTable.HasNext)
                    {                        
                        DbObject singleName = TailorUtil.GetTerm(
                            singleTable.Source) as DbObject;
                        if ((singleName != null) && !singleName.HasNext)
                        {
                            Identifier identifier = singleName.Identifier;

                            // Not canonicalizing - we're accepting quoted "dual"
                            // as a regular identifier.
                            if (TailorUtil.DUAL.Equals(
                                identifier.ID.ToLowerInvariant()))
                            {
                                node.From = null;
                            }
                        }
                    }
                }
            }
        }

        public override void Perform(Variable node)
        {
            if (node == null)
            {
                throw new ArgumentNullException("node");
            }

            base.Perform(node);

            node.Prefix = '@';
        }

        #endregion

        #region Transformations

        protected abstract FunctionCall GetDateaddCall(DateTimeUnit unit,
            INode number, INode date);

        static void SetTop(QueryExpression query, int limit)
        {
            if (query == null)
            {
                throw new ArgumentNullException("query");
            }

            if (limit <= 0)
            {
                throw new ArgumentOutOfRangeException("limit");
            }

            if (query.LimitFormat != ' ')
            {
                limit = Math.Min(query.RowLimit, limit);
            }

            query.SetLimit('T', limit);
        }

        void ReplaceIntervals(Expression done)
        {
            Expression node = GetExpressionParent(done);
            if (node == null)
            {
                return;
            }

            Interval leftInterval = TailorUtil.GetInterval(node.Left);
            Interval rightInterval = TailorUtil.GetInterval(node.Right);

            if (leftInterval != null)
            {
                if (rightInterval != null)
                {
                    ReplaceBothIntervals(node, leftInterval, rightInterval);
                }
                else
                {
                    ReplaceLeftInterval(node, leftInterval);
                }
            }
            else if (rightInterval != null)
            {
                ReplaceRightInterval(node, rightInterval);
            }
        }

        void ReplaceBothIntervals(Expression node, Interval leftInterval,
            Interval rightInterval)
        {
            if (leftInterval.DateTimeUnit != rightInterval.DateTimeUnit)
            {
                throw new InvalidOperationException(
                    "Can't combine intervals with different units.");
                // well, technically we could (at least for some units), but nobody
                // needed that yet
            }

            if ((node.Operator != ExpressionOperator.Plus) &&
                (node.Operator != ExpressionOperator.Minus))
            {
                throw new InvalidOperationException("Can't multiply intervals.");
            }

            node.Left = new Interval(
                new Expression(leftInterval.GetSignedValue(),
                    node.Operator,
                    rightInterval.GetSignedValue()),
                leftInterval.DateTimeUnit);
            node.Operator = null;
            node.Right = null;

            ReplaceIntervals(node);
        }

        void ReplaceLeftInterval(Expression node, Interval leftInterval)
        {
            if (node.Operator == ExpressionOperator.Plus)
            {
                // base date hasn't been tailored yet - keep it in the future
                // of this traversal
                node.Right = GetDateaddCall(leftInterval.DateTimeUnit,
                    leftInterval.GetSignedValue(),
                    node.Right);
                node.Operator = null;
                node.Left = null;
            }
            else if ((node.Operator == ExpressionOperator.Mult) ||
                (node.Operator == ExpressionOperator.Div))
            {
                // base date hasn't been tailored yet - keep it in the future
                // of this traversal
                node.Right = new Interval(
                    GetMultipliedInterval(leftInterval,
                        node.Right,
                        node.Operator),
                    leftInterval.DateTimeUnit);
                node.Operator = null;
                node.Left = null;

                ReplaceIntervals(node);
            }
            else
            {
                throw new InvalidOperationException(
                    "Subtraction from interval not supported.");
            }
        }

        void ReplaceRightInterval(Expression node, Interval rightInterval)
        {
            if (node.Operator == ExpressionOperator.Plus)
            {
                // base date hasn't been tailored yet - keep it in the future
                // of this traversal
                node.Right = GetDateaddCall(rightInterval.DateTimeUnit,
                    rightInterval.GetSignedValue(),
                    node.Left);
                node.Operator = null;
                node.Left = null;
            }
            else if (node.Operator == ExpressionOperator.Minus)
            {
                Interval negativeInterval = (Interval)(rightInterval.Clone());
                negativeInterval.Positive = !negativeInterval.Positive;

                // base date hasn't been tailored yet - keep it in the future
                // of this traversal
                node.Right = GetDateaddCall(negativeInterval.DateTimeUnit,
                    negativeInterval.GetSignedValue(),
                    node.Left);
                node.Operator = null;
                node.Left = null;
            }
            else if (node.Operator == ExpressionOperator.Mult)
            {
                // base date hasn't been tailored yet - keep it in the future
                // of this traversal
                node.Right = new Interval(
                    GetMultipliedInterval(rightInterval,
                        node.Left,
                        ExpressionOperator.Mult),
                    rightInterval.DateTimeUnit);
                node.Operator = null;
                node.Left = null;

                ReplaceIntervals(node);
            }
            else
            {
                throw new InvalidOperationException(
                    "Division by interval not supported.");
            }
        }

        static INode GetMultipliedInterval(Interval interval,
            INode multiplier, ExpressionOperator op)
        {
            if (interval == null)
            {
                throw new ArgumentNullException("interval");
            }

            if (multiplier == null)
            {
                throw new ArgumentNullException("multiplier");
            }

            if (op == null)
            {
                throw new ArgumentNullException("op");
            }

            INode inner = interval.GetSignedValue();
            IntegerValue integerValue = inner as IntegerValue;
            INode newValue;
            if ((integerValue != null) &&
                (integerValue.Value == 1))
            {
                newValue = multiplier;
            }
            else
            {
                newValue = new Expression(inner, op, multiplier);
            }

            return newValue;
        }

        Expression MakeModCall(FunctionCall functionCall)
        {
            if (functionCall == null)
            {
                throw new ArgumentNullException("functionCall");
            }

            ExpressionItem head = functionCall.ExpressionArguments;
            if (head == null)
            {
                throw new InvalidOperationException("MOD has no arguments.");
            }

            ExpressionItem next = head.Next;
            if (next == null)
            {
                throw new InvalidOperationException("MOD has only one argument.");
            }

            if (next.Next != null)
            {
                throw new InvalidOperationException("MOD has too many arguments.");
            }

            return new Expression(head.Expression,
                m_modOp,
                next.Expression);
        }

        #endregion
    }
}
