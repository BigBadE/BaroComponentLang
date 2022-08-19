using System;
using System.Diagnostics;
using Language.Util;

namespace AST.Patterns
{
    public class LiteralPatternPart : IPatternPart
    {
        public readonly string Literal;
        
        public LiteralPatternPart(string literal)
        {
            Literal = literal;
        }
        
        public ParseResult Matches(char[] input, int start)
        {
            int offset = 0;
            for (int i = 0; i - offset < Literal.Length; i++)
            {
                if (start + i == input.Length)
                {
                    return new ParseResult(-1);
                }
                
                if (char.IsWhiteSpace(input[start + i]))
                {
                    offset++;
                    continue;
                }
                if (input[start + i] != Literal[i - offset])
                {
                    return new ParseResult(-1);
                }
            }
       
            return new ParseResult(Literal.Length + offset);
        }

        public bool Recursable() => false;
    }
}