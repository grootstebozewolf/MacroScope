using System;
using System.Text;

namespace MacroScope
{
    /// <summary>
    /// SQL type cast or convert, i.e. <c>CAST(expression AS type)</c> or <c>CONVERT(nvarchar, expression, 102)</c>.
    /// </summary>
    public sealed class TypeCast : IExpression
    {
        #region Fields

        private IExpression m_expression;

        private string m_type;

        private int? m_precision;

        private int? m_secondPrecision;

        private int? m_style;

        private bool m_isconvert;

        #endregion

        #region Constructor

        public TypeCast(IExpression expression, string type)
        {
            if (expression == null)
            {
                throw new ArgumentNullException("expression");
            }

            if (type == null)
            {
                throw new ArgumentNullException("type");
            }

            m_expression = expression;
            m_type = type;
            m_isconvert = false;
        }

        public TypeCast(string type)
        {
            if (type == null)
            {
                throw new ArgumentNullException("type");
            }
            m_type = type;
            m_isconvert = true;
        }

        #endregion

        #region Properties

        public IExpression Expression
        {
            get { return m_expression; }
            set { m_expression = value; }
        }

        public string Type
        {
            get { return m_type; }
            set { m_type = value; }
        }

        public int? Precision
        {
            get { return m_precision; }
            set { m_precision = value; }
        }

        public int? SecondPrecision
        {
            get { return m_secondPrecision; }
            set { m_secondPrecision = value; }
        }

        public bool IsComposed
        {
            get { return false; }
        }

        public bool IsConvert
        {
            get { return m_isconvert; }
            set { m_isconvert = value; }
        }

        public int? Style
        {
            get { return m_style; }
            set { m_style = value; }
        }

        #endregion

        #region INode Members

        public INode Clone()
        {
            TypeCast typeCast = new TypeCast((IExpression)(m_expression.Clone()),
                m_type);
            typeCast.Precision = m_precision;
            typeCast.SecondPrecision = m_secondPrecision;
            typeCast.Style = m_style;
            typeCast.IsConvert = m_isconvert;
            return typeCast;
        }

        public void Traverse(IVisitor visitor)
        {
            if (visitor == null)
            {
                throw new ArgumentNullException("visitor");
            }

            visitor.PerformBefore(this);
            m_expression.Traverse(visitor);
            visitor.PerformAfter(this);
        }

        #endregion
    }
}
