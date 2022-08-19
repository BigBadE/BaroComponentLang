using System;
using Language.Effects;
using Language.Util;

namespace Language.Structure
{
    [Instancable("var %name% [= %value%]")]
    public class Variable : IMainField
    {
        public readonly IVariableOwner? Parent;
        public readonly object? DefaultValue;
        public readonly string Name;

        public Variable(string name, IVariableOwner? parent, object? defaultValue = null)
        {
            Parent = parent;
            DefaultValue = defaultValue;
            Name = name;
        }
    }
}