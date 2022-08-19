namespace Language.Expressions
{
    public abstract class Expression
    {
        public abstract object Precompute();

        public static Expression? Parse(string line, bool nullable = false)
        {
            return null;
        }
    }
}