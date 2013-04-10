using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MacroScope
{
    public class DateTimeFunction : IExpression
    {
        private IExpression m_expression;
        private DateTimeUnit m_datepart;
        private IExpression m_number;
        private int m_functiontype;

        public static readonly int DateAdd = 1;
        public static readonly int DateDiff = 2;

        public DateTimeFunction(IExpression iExpression, DateTimeUnit mDatepart)
        {
            m_expression = iExpression;
            m_datepart = mDatepart;
        }
        public DateTimeFunction(IExpression iExpression, DateTimeUnit mDatepart, IExpression iNumber, int iFunctionType)
        {
            m_expression = iExpression;
            m_datepart = mDatepart;
            m_number = iNumber;
            m_functiontype = iFunctionType;
        }
        #region INode Members
        /// <summary>
        /// Generally deep clone, except for objects with no state
        /// (or private constructors), which return themselves.
        /// </summary>
        /// <returns>
        /// A copy of this node (never null).
        /// </returns>
        public INode Clone()
        {
            DateTimeFunction dateTimeFunction = new DateTimeFunction((IExpression)(m_expression.Clone()),
                (DateTimeUnit)m_datepart.Clone());
            return dateTimeFunction;
        }

        /// <summary>
        /// The accept method of a visitor pattern.
        /// </summary>
        /// <param name="visitor">
        /// The accepted visitor. Must not be null.
        /// </param>
        public void Traverse(IVisitor visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException("visitor");
            }

            visitor.PerformBefore(this);
            if(m_number != null)
            {
                visitor.PerformBeforeNumber(this);
                m_number.Traverse(visitor);
                visitor.PerformAfterNumber(this);
            }
            m_expression.Traverse(visitor);
            visitor.PerformAfter(this);
        }
        public bool IsComposed
        {
            get { return false; }
        }

        public DateTimeUnit Datepart
        {
            get { return m_datepart; }
        }

        public int FunctionType
        {
            get { return m_functiontype; }
        }

        #endregion


    }
}
