using System.Collections.Generic;
using Language.Effects;
using Language.Expressions;
using Language.Util;

namespace Language.Structure
{
    [Instancable("var %name%[=%value%]")]
    public class Variable : Expression, IMainField
    {
        [Argument(0)]
        public string Name;
        [Argument(1, true)]
        public Effect? DefaultValue;

        public override object? Precompute() => DefaultValue?.Precompute() ?? null;

        public string ToString(bool dropVar)
        {
            if (DefaultValue == null)
            {
                return dropVar ? Name : "var " + Name;
            }

            return dropVar ? Name + " = " + DefaultValue : "var " + Name + " = " + DefaultValue;
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