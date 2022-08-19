using System.Collections.Generic;
using System.Text;
using Language.Listener;
using Language.Structure;

namespace AST.Tree
{
    public class ASTTree
    {
        public Dictionary<Listener, string> Listeners = new();
        public List<Variable> Variables = new();
        public List<Method> Methods = new();

        public override string ToString()
        {
            StringBuilder builder = new();
            foreach (KeyValuePair<Listener,string> pair in Listeners)
            {
                builder.Append(pair.Key.Device).Append('_').Append(pair.Key.Connector).Append(" -> ")
                    .Append(pair.Value).Append('\n');
            }

            foreach (Variable variable in Variables)
            {
                builder.Append("var ").Append(variable.Name);
                if (variable.DefaultValue != null)
                {
                    builder.Append(" = ").Append(variable.DefaultValue);
                }
                builder.Append('\n');
            }

            foreach (Method method in Methods)
            {
                builder.Append(method);
            }
            return builder.ToString();
        }
    }
}