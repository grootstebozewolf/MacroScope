using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MacroScope
{
    public class DropStatement: IStatement
    {
        /// <summary>
        /// Generally deep clone, except for objects with no state
        /// (or private constructors), which return themselves.
        /// </summary>
        /// <returns>
        /// A copy of this node (never null).
        /// </returns>
        public INode Clone()
        {
            DropStatement dropStatement = new DropStatement();
            return dropStatement;
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
            visitor.PerformAfter(this);
        }
    }
}
