using System.Collections.Generic;
using System.Linq;
using System.Text;
using Language.Expressions;
using Language.Util;

namespace Language.Structure
{
    [Instancable("func %name%([%arguments%]){")]
    public class Method : IVariableOwner, IMainField
    {
        public string Name;
        public Variable[] Args { get; private set; }
        public List<Expression> Expressions = new();

        public void Init(List<object> args)
        {
            Name = (string) args[0];
            Args = (Variable[]) args[1];
        }

        public override string ToString()
        {
            StringBuilder builder = new();

            builder.Append("func ").Append(Name).Append("(");
            for (int i = 0; i < Args.Length-1; i++)
            {
                builder.Append(Args[i].ToString(true)).Append(", ");
            }

            if (Args.Any())
            {
                builder.Append(Args[^1].ToString(true));
            }

            builder.Append(") {\n");
            foreach (Expression expression in Expressions)
            {
                builder.Append("    ").Append(expression).Append('\n');
            }

            builder.Append("}\n");
            
            return builder.ToString();
        }
    }
}