using System;
using System.Collections.Generic;
using Language.Effects;
using Language.Expressions;
using Language.Util;

namespace Language.Structure
{
    [Instancable("var %name% [= %value%]")]
    public class Variable : Expression, IMainField
    {
        public string Name;
        public Effect? DefaultValue = null;

        public override object? Precompute() => DefaultValue?.Precompute() ?? null;

        public override void Init(List<object>? args)
        {
            Name = (string) args![0];
            if (args.Count > 0)
            {
                DefaultValue = (Effect) args[1];
            }
        }
    }
}