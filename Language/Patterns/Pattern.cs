using System.Collections.Generic;
using System.Threading;

namespace Language.Patterns
{
    public class Pattern
    {
        private List<IPatternPart> parts = new();
        
        public Pattern(string pattern)
        {
            PatternParserState state = PatternParserState.Literal;
            int start = 0;
            for (int i = 0; i < pattern.Length; i++)
            {
                char found = pattern[i];
                switch (state)
                {
                    case PatternParserState.Literal:
                        if (found == '%')
                        {
                            string literal = pattern.Substring(start, i).Trim();
                            if (literal.Length > 0)
                            {
                                parts.Add(new LiteralPart(literal));
                            }
                            state = PatternParserState.Special;
                        }
                        break;
                    case PatternParserState.Special:
                        if (found == '%')
                        {
                            
                        }
                        break;
                }
            }
        }
    }

    enum PatternParserState
    {
        Literal,
        Special
    }
}