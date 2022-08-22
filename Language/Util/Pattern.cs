using System.Collections.Generic;
using System.Linq;

namespace Language.Util
{
    public class Pattern
    {
        private readonly IPatternPart[] _parts;

        public Pattern(IPatternPart[] parts)
        {
            _parts = parts;
        }

        public ParseResult Matches(char[] input, int start, int length = -1)
        {
            if (!_parts.Any())
            {
                return new ParseResult(-1);
            }

            int oldStart = start;
            List<object> results = new();
            do
            {
                foreach (IPatternPart part in _parts)
                {
                    if (results.Any() && part == _parts[0])
                    {
                        continue;
                    }

                    ParseResult output = part.Matches(input, start);

                    if (output.Length == -1)
                    {
                        return new ParseResult(-1);
                    }

                    if (output.Values != null)
                    {
                        results.Add(output.Values);
                    }

                    start += output.Length;
                }

                if (start < length && (!_parts[0].Recursable() || results.Any()))
                {
                    return new ParseResult(-1);
                }
            } while (start < length);

            return new ParseResult(start - oldStart, results);
        }
    }
}