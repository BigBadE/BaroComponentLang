using System.Collections.Generic;
using Language.Effects;
using Language.Structure;

namespace Language.Expressions.Control
{
    public abstract class ControlExpression : Expression, IVariableOwner
    {
        public readonly List<Expression> Lines = new();

        public ControlExpression? Parent;
        public Effect[] Args;
    }
}