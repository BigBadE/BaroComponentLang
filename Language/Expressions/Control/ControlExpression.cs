using System;
using System.Collections.Generic;
using System.Reflection;
using Language.Effects;
using Language.Structure;
using Language.Util;

namespace Language.Expressions.Control
{
    public abstract class ControlExpression : Expression, IVariableOwner
    {
        [SubTypeList(typeof(ControlExpression))]
        public static List<Type> ControlExpressions;

        public readonly List<Expression> Lines = new();
        
        public ControlExpression? Parent { get; private set; }
        public Effect[] Args { get; private set; }

        public static ControlExpression Parse(string name, string args, ControlExpression? parent)
        {
            ControlExpression target = InstancableAttribute.Construct<ControlExpression>(
                ControlExpressions.Find(expression => 
                    expression.GetCustomAttribute<InstancableAttribute>()?.Name == name) ??
                throw new Exception("No control statement called " + name));

            target.Parent = parent;
            target.Args = ParseArgs(args);
            return target;
        }

        private static Effect[] ParseArgs(string args)
        {
            List<Effect> parsedArgs = new();
            bool escaped = false;
            int start = 0;
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case '"':
                        escaped = !escaped;
                        break;
                    case ';':
                        if (escaped)
                        {
                            break;
                        }
                        parsedArgs.Add(Effect.Parse(args.Substring(start, i-1).Trim())!);
                        start = i;
                        break;
                }
            }

            if (start != args.Length)
            {
                parsedArgs.Add(Effect.Parse(args[start..])!);
            }

            return parsedArgs.ToArray();
        }
    }
}