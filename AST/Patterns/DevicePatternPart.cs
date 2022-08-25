using System;
using System.Collections.Generic;
using Compiler.Components;
using Language.Effects;
using Language.Util;

namespace AST.Patterns
{
    public class DevicePatternPart : IPatternPart
    {
        public ParseResult Matches(char[] input, int start)
        {
            foreach (IComponent component in IComponent.Components)
            {
                string name = component.ToString()!;
                if (input.Length - start > name.Length)
                {
                    continue;
                }

                bool failed = false;
                for (int i = 0; i < name.Length; i++)
                {
                    if (input[start + i] != name[i])
                    {
                        failed = true;
                    }
                }

                if (!failed)
                {
                    return new ParseResult(name.Length, name);
                }
            }

            return new ParseResult(-1);
        }

        public bool Recursable() => true;
    }
}