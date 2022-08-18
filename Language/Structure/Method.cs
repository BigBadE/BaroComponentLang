using System.Collections.Generic;
using Language.Effects;
using Language.Expressions;

namespace Language.Structure
{
    public class Method : IVariableOwner
    {
        public readonly string Name;
        public Variable[] Args { get; private set; }
        public List<Expression> Expressions = new();

        private Method(string name)
        {
            Name = name;
        }

        public static Method Parse(string name, string args)
        {
            Method method = new(name);
            method.ParseArgs(args);
            return method;
        }

        private void ParseArgs(string args)
        {
            List<Variable> parsedArgs = new();
            bool escaped = false;
            int start = 0;
            object? value = null;
            string? name = null;
            for (int i = 0; i < args.Length; i++)
            {
                switch (args[i])
                {
                    case '"':
                        escaped = !escaped;
                        break;
                    case '=':
                        if (escaped)
                        {
                            break;
                        }
                        name = args.Substring(start, i - 1).Trim();
                        start = i;
                        break;
                    case ',':
                        if (escaped)
                        {
                            break;
                        }
                        if (name == null)
                        {
                            name = args.Substring(start, i - 1);
                        }
                        else
                        {
                            value = Effect.Parse(args.Substring(start, i - 1))!.Precompute();
                        }
                        parsedArgs.Add(new Variable(name, this, value));
                        start = i;
                        name = null;
                        value = null;
                        break;
                }
            }

            if (start == args.Length)
            {
                 Args = parsedArgs.ToArray();
                 return;
            }
            
            if (name == null)
            {
                parsedArgs.Add(new Variable(args[start..], this));
            }
            else
            {
                parsedArgs.Add(new Variable(name, this, 
                    Effect.Parse(args[start..])!.Precompute()));
            }

            Args = parsedArgs.ToArray();
        }
    }
}