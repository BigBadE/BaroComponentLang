using Language.Util;

namespace AST.Pattern
{
    public class LiteralPatternPart : IPatternPart
    {
        private readonly string _literal;
        
        public LiteralPatternPart(string literal)
        {
            _literal = literal;
        }
        
        public ParseResult Matches(char[] input, int start)
        {
            if (input.Length < start + _literal.Length)
            {
                return new ParseResult(-1);
            }
            
            for (int i = 0; i < _literal.Length; i++)
            {
                if (input[start + i] != _literal[i])
                {
                    return new ParseResult(-1);
                }
            }

            return new ParseResult(_literal.Length, _literal);
        }
    }
}