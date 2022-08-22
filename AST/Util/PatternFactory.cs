using System;
using System.Collections.Generic;
using AST.Patterns;
using Language.Util;

namespace AST.Util
{
    public static class PatternFactory
    {
        public static Pattern Compile(string input)
        {
            int start = 0;
            input = input.Replace(" ", null);
            return new Pattern(Compile(input, ref start).ToArray());
        }
        
        private static List<IPatternPart> Compile(string input, ref int start, char? exit = null)
        {
            List<IPatternPart> parts = new();
            
            for (int i = start; i < input.Length; i++)
            {
                char current = input[i];

                if (current == exit)
                {
                    if (i != start)
                    {
                        parts.Add(new LiteralPatternPart(input.Substring(start, i-1)));
                    }

                    start = i;
                    return parts;
                }

                switch (current)
                {
                    case '[':
                        if (i != start)
                        {
                            parts.Add(new LiteralPatternPart(input.Substring(start, i)));
                        }
                        
                        start = ++i;
                        parts.Add(new OptionalPatternPart(new Pattern(
                            Compile(input, ref start, ']').ToArray())));
                        i = start;
                        break;
                    case '%':
                        if (i != start)
                        {
                            parts.Add(new LiteralPatternPart(input.Substring(start, i)));
                        }

                        start = ++i;
                        string found = (Compile(input, ref start, '%')[0] as LiteralPatternPart)!.Literal;
                        start = i;
                        
                        switch (found)
                        {
                            case "value":
                                parts.Add(new ValuePatternPart());
                                break;
                            case "number":
                                parts.Add(new NumberPatternPart());
                                break;
                            case "name":
                                parts.Add(new NamePatternPart());
                                break;
                            case "string":
                                parts.Add(new StringPatternPart());
                                break;
                            case "arguments":
                                parts.Add(new ArgumentPatternPart());
                                break;
                            default:
                                throw new Exception("Unknown special pattern " + found);
                        }
                        break;
                }
            }

            if (exit != null)
            {
                throw new Exception("Unescaped special character in " + input);
            }

            if (start == input.Length)
            {
                return parts;
            }
            
            parts.Add(new LiteralPatternPart(input[start..]));
            return parts;
        }
    }
}