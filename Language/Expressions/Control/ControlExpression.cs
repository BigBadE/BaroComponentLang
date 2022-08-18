using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AST.Util;

namespace AST.Tree
{
    public abstract class ControlExpression : Expression, IVariableOwner
    {
        [SubTypeList(typeof(ControlExpression))]
        public static List<Type> ControlExpressions;

        public ControlExpression? parent;

        public Effect[] args;
        public List<Expression> lines = new();
        
        public static ControlExpression Parse(string name, string args, ControlExpression? parent)
        {
            ControlExpression target = InstancableAttribute.Construct<ControlExpression>(
                ControlExpressions.Find(expression => 
                    expression.GetCustomAttribute<InstancableAttribute>()?.name == name) ??
                throw new Exception("No control statement called " + name));

            target.parent = parent;
            target.args = ParseArgs(args);
            return target;
        }

        private static Effect[] ParseArgs(string args)
        {
            List<Effect> parsedArgs = new();
            bool escaped = false;
            int start = 0;
            int i = 0;
            foreach (char c in args)
            {
                switch (c)
                {
                    case '"':
                        escaped = !escaped;
                        break;
                    case ';':
                        parsedArgs.Add(Effect.Parse(args.Substring(start, i))!);
                        start = i;
                        break;
                }

                i++;
            }

            if (i != start)
            {
                parsedArgs.Add(Effect.Parse(args.Substring(start, i))!);
            }

            return parsedArgs.ToArray();
        }
    }
}