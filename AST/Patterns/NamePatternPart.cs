using Language.Util;

namespace AST.Patterns
{
    public class NamePatternPart : IPatternPart
    {
        public ParseResult Matches(char[] input, int start)
        {
            for (int i = start; i < input.Length; i++)
            {
                char testing = input[i];
                if (testing is not (>= 'a' and <= 'z' or >= 'A' and <= 'Z' or '-' or '_'))
                {
                    return new ParseResult(i - start, new string(input, start, i));
                }
            }
            return new ParseResult(input.Length - start, new string(input, start, input.Length-start));
        }

        public bool Recursable() => false;
    }
}