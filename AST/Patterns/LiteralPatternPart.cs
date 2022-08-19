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
            int offset = 0;
            for (int i = 0; i - offset < _literal.Length; i++)
            {
                if (i > input.Length)
                {
                    return new ParseResult(-1);
                }
                
                if (char.IsWhiteSpace(input[start + i]))
                {
                    offset++;
                    continue;
                }
                if (input[start + i] != _literal[i - offset])
                {
                    return new ParseResult(-1);
                }
            }

            return new ParseResult(_literal.Length + offset);
        }

        public bool Recursable() => false;
    }
}