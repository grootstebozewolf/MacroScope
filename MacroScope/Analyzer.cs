using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MacroScope
{
    public class Analyzer : TracingVisitor
    {
        public HashSet<string> Tables = new HashSet<string>();
        public HashSet<string> Alias = new HashSet<string>();
        public HashSet<string> Columns = new HashSet<string>();
        public HashSet<string> Parameters = new HashSet<string>();

        public override void Perform(StringValue node)
        {
            if(node.Value.StartsWith("$"))
            {
                if (!Parameters.Contains(node.Value.Trim('$', '%')))
                {
                    Parameters.Add(node.Value.Trim('$', '%'));
                }
            }
            base.Perform(node);
        }

        public override void PerformAfter(DbObject node)
        {
            if(!node.IsParam)
            {
                //Console.Write("DBObject:"+node.Identifier);
                //if (node.HasNext)
                //    Console.WriteLine("." + node.Next.Identifier);
                //else
                //{
                //    Console.WriteLine();
                //}
                if (node.HasNext)
                {
                    if (!Columns.Contains(node.Next.Identifier.ToString()))
                    {
                        Columns.Add(node.Next.Identifier.ToString());
                    }
                }
                else
                {
                    if (node.Identifier.ToString().StartsWith("fv_"))
                    {
                        if (!Tables.Contains(node.Identifier.ToString()))
                        {
                            Tables.Add(node.Identifier.ToString());
                        }
                    }
                    if (!Alias.Contains(node.Identifier.ToString()))
                    {
                        if (!Columns.Contains(node.Identifier.ToString()))
                        {
                            Columns.Add(node.Identifier.ToString());
                        }
                    }
                }   
            }
            else
            {
                if (node.HasNext)
                {
                    if (!Parameters.Contains(node.Identifier + "." + node.Next.Identifier))
                    {
                        Parameters.Add(node.Identifier + "." + node.Next.Identifier);
                    }
                }
            }
            
            base.PerformAfter(node);
        }
        public override void PerformAfter(AliasedItem node)
        {
            if (node.Alias != null)
            {
                if (!Alias.Contains(node.Alias.ToString()))
                {
                    Alias.Add(node.Alias.ToString());
                }
            }
            base.PerformAfter(node);
        }
    }
}
