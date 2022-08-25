using System.Collections.Generic;
using AST.Util;
using Language.Structure;
using Language.Util;

namespace AST.Patterns
{
    public class ArgumentPatternPart : IPatternPart
    {
        private static Pattern _pattern = PatternFactory.Compile("%name%[ = %value]");

        public ParseResult Matches(char[] input, int start)
        {
            int oldStart = start;
            List<Variable> args = new();
            ParseResult result = _pattern.Matches(input, start);
            while (result.Length != -1)
            {
                start += result.Length;
                Variable found = new();
                ASTParser.Init(found, result.Values);
                args.Add(found);
                
                if (input[start] == ',')
                {
                    start++;
                }
                else
                {
                    break;
                }
                result = _pattern.Matches(input, start);
            }

            return new ParseResult(start - oldStart, args.ToArray());
        }

        public bool Recursable() => false;
    }
}