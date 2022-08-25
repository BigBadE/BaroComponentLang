using Language.Util;

namespace AST.Patterns
{
    public class OptionalPatternPart : IPatternPart
    {
        private readonly Pattern _pattern;
        
        public OptionalPatternPart(Pattern pattern)
        {
            _pattern = pattern;
        }
        
        public ParseResult Matches(char[] input, int start)
        {
            ParseResult result = _pattern.Matches(input, start);
            return result.Length != -1 ? result : new ParseResult(0);
        }

        public bool Recursable() => false;
    }
}