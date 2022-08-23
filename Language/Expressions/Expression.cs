namespace Language.Expressions
{
    public abstract class Expression
    {
        public abstract object? Precompute();
    }
}