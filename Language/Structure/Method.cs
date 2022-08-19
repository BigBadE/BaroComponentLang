using System.Collections.Generic;
using Language.Effects;
using Language.Expressions;
using Language.Util;

namespace Language.Structure
{
    [Instancable("func %name%[ ]([%value%]){")]
    public class Method : IVariableOwner, IMainField
    {
        public string Name;
        public Variable[] Args { get; private set; }
        public List<Expression> Expressions = new();

        public void Init(List<object> args)
        {
            Name = (string) args[0];
            
        }
    }
}