using System;
using Language.Effects;

namespace Language.Structure
{
    public class Variable
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
        
        public static Variable Parse(IVariableOwner? owner, string name, string? value)
        {
            if (value == null)
            {
                return new Variable(name, owner);
            }
            Effect? found = Effect.Parse(value);
            if (found == null)
            {
                throw new Exception("Unknown effect " + found);
            }

            return new Variable(name, owner, found.Precompute());
        }
    }
}