using System;
using System.Collections.Generic;
using AST.Pattern;
using Language.Util;

namespace AST.Util
{
    public static class PatternFactory
    {
        public static Language.Util.Pattern Compile(string input)
        {
            List<IPatternPart> parts = new();
            
            int start = 0;
            bool special = false;
            for (int i = 0; i < input.Length; i++)
            {
                char current = input[i];

                switch (current)
                {
                    case '%':
                        string found = input.Substring(start, i-1);
                        if (special)
                        {
                            switch (found)
                            {
                                case "value":
                                    parts.Add(new ValuePatternPart());
                                    break;
                            }
                        }
                        else
                        {
                            parts.Add(new LiteralPatternPart(found));
                        }

                        start = i;
                        special = !special;
                        break;
                }
            }

            if (start == input.Length)
            {
                return new Language.Util.Pattern(parts.ToArray());
            }
            
            if (special)
            {
                throw new Exception("Unclosed special argument in pattern " + input);
            }

            parts.Add(new LiteralPatternPart(input[start..]));
            return new Language.Util.Pattern(parts.ToArray());
        }
    }
}