using System;
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
            if (length == -1)
            {
                length = input.Length;
            }
            
            int oldStart = start;
            bool found = true;
            List<object> results = new();
            while (start < length)
            {
                while (found)
                {
                    found = false;
                    foreach (IPatternPart part in _parts)
                    {
                        if (results.Any() && part == _parts[0])
                        {
                            continue;
                        }
                        
                        ParseResult output = part.Matches(input, start);

                        if (output.Length == -1)
                        {
                            continue;
                        }

                        if (output.Values != null)
                        {
                            results.Add(output.Values);
                        }

                        found = true;
                        start += output.Length;
                        break;
                    }
                }

                if (start < length && (!_parts[0].Recursable() || results.Any()))
                {
                    return new ParseResult(-1);
                }
            }

            return new ParseResult(start-oldStart, results);
        }
    }
}