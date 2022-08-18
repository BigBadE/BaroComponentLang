using System;

namespace AST.Tree
{
    public class Variable
    {
        public IVariableOwner? parent;
        public object defaultValue;
        public string name;

        public static Variable Parse(IVariableOwner? owner, string name, string? value)
        {
            Variable variable = new()
            {
                parent = owner,
                name = name
            };
            if (value == null)
            {
                return variable;
            }
            Effect? found = Effect.Parse(value);
            if (found == null)
            {
                throw new Exception("Unknown effect " + found);
            }
            if (found.Args() != 0)
            {
                throw new Exception("Variable " + name + " has a non-constant value. This will be supported later!");
            }

            variable.defaultValue = found.Precompute();
            return variable;
        }
    }
}