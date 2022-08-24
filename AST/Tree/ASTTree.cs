using System.Collections.Generic;
using System.Text;
using Language.Listener;
using Language.Structure;

namespace AST.Tree
{
    public class ASTTree
    {
        public List<Listener> Listeners = new();
        public List<Variable> Variables = new();
        public List<Method> Methods = new();

        public override string ToString()
        {
            StringBuilder builder = new();
            foreach (Listener listener in Listeners)
            {
                builder.Append(listener).Append('\n');
            }

            foreach (Variable variable in Variables)
            {
                builder.Append(variable).Append('\n');
            }

            foreach (Method method in Methods)
            {
                builder.Append(method);
            }
            return builder.ToString();
        }
    }
}