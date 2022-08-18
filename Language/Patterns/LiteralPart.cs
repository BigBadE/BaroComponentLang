namespace Language.Patterns
{
    public class LiteralPart : IPatternPart
    {
        private string _literal;
        
        public LiteralPart(string literal)
        {
            _literal = literal;
        }

        public ParseResult ParseWord(char[] buffer, int start, int length)
        {
            for (int i = 0; i < length; i++)
            {
                if (buffer[i + start] != _literal[i])
                {
                    return ParseResult.Failed;
                }
            }

            return length == _literal.Length ? ParseResult.Passed : ParseResult.Undetermined;
        }
    }
}