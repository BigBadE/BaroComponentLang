using Language.Expressions;
using Language.Types;

namespace Language.Effects
{
    public abstract class Effect : Expression
    {
        public abstract TypesEnum ReturnType();
    }
}