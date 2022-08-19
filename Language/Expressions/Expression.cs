using System.Collections.Generic;

namespace Language.Expressions
{
    public abstract class Expression
    {
        public abstract object? Precompute();

        public abstract void Init(List<object>? args);
    }
}