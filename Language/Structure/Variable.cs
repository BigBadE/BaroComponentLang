using System.Collections.Generic;
using Language.Effects;
using Language.Expressions;
using Language.Util;

namespace Language.Structure
{
    [Instancable("var %name%[=%value%]")]
    public class Variable : Expression, IMainField
    {
        public string Name;
        public Effect? DefaultValue;

        public override object? Precompute() => DefaultValue?.Precompute() ?? null;

        public override void Init(List<object>? args)
        {
            Name = (string) args![0];
            if (args.Count > 0)
            {
                DefaultValue = (Effect) args[1];
            }
        }

        public string ToString(bool dropVar)
        {
            if (DefaultValue == null)
            {
                return dropVar ? Name : "var " + Name;
            }
            else
            {
                return dropVar ? Name + " = " + DefaultValue : "var " + Name + " = " + DefaultValue;
            }
        }

        public override string ToString()
        {
            if (DefaultValue == null)
            {
                return "var " + Name;
            }
            return "var " + Name + " = " + DefaultValue;
        }
    }
}