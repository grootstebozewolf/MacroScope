using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MacroScope
{
    public class Dot : TracingVisitor
    {
        private StringBuilder m_dot;
        private INode m_table;
        private bool m_issubselect;

        public enum columnType
        {
            Default = 0, 
            TableName,
            ColumnName
        }

        private columnType m_columnType;
        private StatementType mStatementType;
        private bool m_isclosed = false;

        private enum StatementType
        {
            InsertStatement = 1,
            UpdateStatement,
            SelectStatement,
            DeleteStatement
        };

        public Dot()
        {
            m_dot = new StringBuilder();
            m_dot.AppendLine(@"digraph dbObjects {");

        }

        #region Implementation of IVisitor

        public override void Perform(StringValue node)
        {
            if (m_columnType == columnType.TableName)
            {
                m_dot.Append("table_name -> ");
                m_dot.Append(node.Value);
                m_dot.Append(";");
                m_dot.Append(Environment.NewLine);
            }
            if(m_columnType == columnType.ColumnName)
            {
                m_dot.Append("column_name -> ");
                m_dot.Append(node.Value);
                m_dot.Append(";");
                m_dot.Append(Environment.NewLine);
            }
            base.Perform(node);
        }

        public override void PerformBefore(DbObject node)
        {
            if ((Parent is UpdateStatement) && (m_table == null))
            {
                m_table = node.Identifier;
            }
            if ((Parent is InsertStatement) && (m_table == null))
            {
                m_table = node.Identifier;
            }
            if ((Parent is Assignment) && (m_table != null))
            {
                if (m_table is Identifier)
                {
                    m_dot.Append(((Identifier)m_table).ID);
                }
                m_dot.Append(" -> ");
                m_dot.Append(node.Identifier.ID);
                m_dot.Append(";");
                m_dot.Append(Environment.NewLine);
            }
            if ((Parent is Expression) && node.HasNext)
            {
                m_dot.Append(node.Identifier.ID);
                m_dot.Append(" -> ");
                m_dot.Append(node.Next.Identifier.ID);
                m_dot.Append(";");
                m_dot.Append(Environment.NewLine);
                node.Next.Identifier.IsActive = false;
            }
            else if ((Parent is Expression) && (node.Identifier.IsActive))
            {
                var query = GetAncestor<QueryExpression>(null, null);
                if (query != null)
                {
                    if (query.From != null)
                    {
                        if (query.From.Item != null)
                        {
                            var from = query.From.Item;
                            if (from is Table)
                            {
                                Table table = from as Table;
                                if (table.HasNext == false)
                                {
                                    m_table = table.Source;
                                }
                            }
                        }
                    }
                }
                if (m_table is Identifier)
                {
                    m_dot.Append(((Identifier)m_table).ID);
                }
                else if (m_table is DbObject)
                {
                    DbObject dbObject = m_table as DbObject;
                    m_dot.Append(dbObject.Identifier.ID);
                    if (((DbObject)m_table).HasNext)
                    {
                        m_dot.Append(".");
                        m_dot.Append(dbObject.Next.Identifier.ID);
                    }
                }
                if (node.Identifier.ID == "table_name")
                    m_columnType = columnType.TableName;
                else if (node.Identifier.ID == "column_name")
                    m_columnType = columnType.ColumnName;
                else
                {
                    m_columnType = columnType.Default;
                }
                m_dot.Append(" -> ");
                m_dot.Append(node.Identifier.ID);
                m_dot.Append(";");
                m_dot.Append(Environment.NewLine);
            }
            else if ((Parent is AliasedItem) && (m_table != null))
            {
                if (m_table is Identifier)
                {
                    m_dot.Append(((Identifier)m_table).ID);
                }
                else if (m_table is DbObject)
                {
                    DbObject dbObject = m_table as DbObject;
                    m_dot.Append(dbObject.Identifier.ID);
                    m_dot.Append(".");
                    m_dot.Append(dbObject.Next.Identifier.ID);
                }
                m_dot.Append(" -> ");
                m_dot.Append(node.Identifier.ID);
                m_dot.Append(";");
                m_dot.Append(Environment.NewLine);
            } 
            else if (node.Identifier.ID.StartsWith("fv_") && (node.HasNext == false) && (m_table == null))
            {
                m_table = node.Identifier;
            }
            else if (node.Identifier.ID.StartsWith("information_schema") && (m_table == null))
            {
                m_table = node;
            }
            base.PerformBefore(node);
        }

        public override void PerformBefore(InsertStatement node)
        {
            mStatementType = StatementType.InsertStatement;
            m_dot.AppendLine("subgraph insert {");
            base.PerformBefore(node);
        }

        //public override void PerformBefore(QueryExpression node)
        //{
        //    //if (m_issubselect)
        //    //{
        //    //    //m_dot.AppendLine("}");
        //    //    m_dot.AppendLine("subgraph subselect {");
        //    //}
        //    //else
        //    //{
        //    base.PerformBefore(node);
        //}

        //public override void PerformOnAlias(AliasedItem node)
        //{
        //    if ((node.Item is Table)
        //        && (((Table)node.Item).Alias!=null))
        //    {
        //        m_dot.Append(((DbObject)((Table)node.Item).Source).Identifier.ID);
        //        m_dot.Append(" -> ");
        //        m_dot.Append(((Table)node.Item).Alias.ID);
        //        m_dot.Append(";");
        //        m_dot.Append(Environment.NewLine);
        //    }
        //    base.PerformOnAlias(node);
        //}

        //public override void PerformOnWhere(QueryExpression node)
        //{
        //    node.SelectItems.Traverse(this);
        //    base.PerformOnWhere(node);
        //}

        //public override void PerformAfter(QueryExpression node)
        //{
        //    QueryExpression query = GetAncestor<QueryExpression>(null, null);
        //    if (query != null)
        //    {
        //        m_dot.AppendLine("}");
        //    }
        //    base.PerformAfter(node);
        //}

        public override void PerformBefore(UpdateStatement node)
        {
            mStatementType = StatementType.UpdateStatement;
            m_dot.AppendLine("subgraph update {");
            base.PerformBefore(node);
        }

        public override void PerformAfter(UpdateStatement node)
        {
            m_dot.AppendLine("}");
            base.PerformAfter(node);
        }
        public override void PerformAfter(InsertStatement node)
        {
            m_dot.AppendLine("}");
            base.PerformAfter(node);
        }
        public override void PerformBefore(SelectStatement node)
        {
            if (GetAncestor<QueryExpression>(null, null) == null)
            {
                mStatementType = StatementType.SelectStatement;
                m_dot.AppendLine("subgraph select {");
            }
            base.PerformBefore(node);
        }

        public override  void PerformAfter(SelectStatement node)
        {
            if (GetAncestor<QueryExpression>(null, null) == null)
            {
                m_dot.AppendLine("}");
            }
            base.PerformAfter(node);
        }

        //public override void PerformOnDerivedTables(InsertStatement node)
        //{
        //    m_issubselect = false;
        //    m_dot.AppendLine("}");
        //    if (mStatementType != StatementType.DeleteStatement)
        //    m_table = null;
        //    base.PerformOnDerivedTables(node);
        //}

        public override void PerformBefore(DeleteStatement node)
        {
            mStatementType = StatementType.DeleteStatement;
            m_dot.AppendLine("subgraph delete {");
            m_table = node.Table;
            base.PerformBefore(node);
        }

        public override void PerformAfter(DeleteStatement node)
        {
            m_dot.AppendLine("}");
            base.PerformAfter(node);
        }

        public override void PerformOnSource(Table node)
        {
            if (node.Alias != null && (node.Source is DbObject))
            {
                m_dot.Append(((DbObject)node.Source).Identifier.ID);
                m_dot.Append(" -> ");
            }
            base.PerformOnSource(node);
        }

        public override void PerformOnAlias(Table node)
        {
            if (node.Alias != null)
            {
                m_dot.Append(node.Alias.ID);
                m_dot.Append(";");
                m_dot.Append(Environment.NewLine);
            }
            base.PerformOnAlias(node);
        }


        #endregion

        public string graphviz()
        {
            if (!m_isclosed)
            {
                m_isclosed = true;
                m_dot.AppendLine("}");
            }
            return m_dot.ToString();
        }
    }

}
