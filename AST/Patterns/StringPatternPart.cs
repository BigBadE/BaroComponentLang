using System.Text;
using Language.Util;

namespace AST.Pattern
{
    public class StringPatternPart : IPatternPart
    {
        public ParseResult Matches(char[] input, int start)
        {
            if (input[start] != '"')
            {
                return new ParseResult(-1);
            }

            bool escaped = false;
            StringBuilder builder = new();
            for (int i = start; i < input.Length; i++)
            {
                char found = input[i];

                if (escaped)
                {
                    builder.Append(found);
                    escaped = false;
                } else switch (found)
                {
                    case '\\':
                        escaped = true;
                        break;
                    case '"':
                        return new ParseResult(i - start, builder.ToString());
                    default:
                        builder.Append(found);
                        break;
                }
            }

            return new ParseResult(-1);
        }

        public bool Recursable() => false;
    }
}