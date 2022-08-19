using System.Collections.Generic;

namespace Language.Util
{
    public class Pattern
    {
        private readonly IPatternPart[] _parts;
        
        public Pattern(IPatternPart[] parts)
        {
            _parts = parts;
        }

        public ParseResult Matches(char[] input, int start)
        {
            int oldStart = start;
            bool found = true;
            List<object> results = new();
            while (found)
            {
                found = false;
                foreach (IPatternPart part in _parts)
                {
                    ParseResult output = part.Matches(input, start);

                    if (output.Length == -1)
                    {
                        continue;
                    }
                    
                    results.Add(output.Values!);
                    found = true;
                    start += output.Length;
                    break;
                }
            }
            
            return new ParseResult(start-oldStart, results);
        }
    }
}