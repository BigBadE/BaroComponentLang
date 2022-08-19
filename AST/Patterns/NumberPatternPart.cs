using Language.Util;

namespace AST.Patterns
{
    public class NumberPatternPart : IPatternPart
    {
        public ParseResult Matches(char[] input, int start)
        {
            float current = 0;
            float decimalValue = -1;
            for (int i = start; i < input.Length; i++)
            {
                switch (input[i])
                {
                    case '.':
                        decimalValue = .1f;
                        break;
                    case <= '9' and >= '0':
                    {
                        current *= 10;
                        float value = input[i] - '0';
                        if (decimalValue == -1)
                        {
                            current += value;
                        }
                        else
                        {
                            current += value * decimalValue;
                            decimalValue /= 10;
                        }

                        break;
                    }
                    default:
                        return new ParseResult(i - start, current);
                }
            }
            return new ParseResult(input.Length - start, current);
        }

        public bool Recursable() => false;
    }
}