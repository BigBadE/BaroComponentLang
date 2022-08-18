namespace Language.Expressions
{
    public enum ExpressionParserState
    {
        Starting,
        Number,
        String,
        Variable,
        Method,
        Arguments
    }
}