using System;
using System.Reflection;
using AST.Util;
using Language.Expressions;

namespace Language.Util
{
    public class InstancableFactory
    {
        private Type _type;
        private Pattern _pattern;

        public InstancableFactory(Type type, Pattern pattern)
        {
            _type = type;
            _pattern = pattern;
        }

        public T Instantiate<T>()
        {
            return (T) _type.GetConstructor(BindingFlags.Default, Array.Empty<Type>())!
                .Invoke(Array.Empty<object>());
        }

        public ParseResult Matches(char[] input, int start, int length = -1)
        {
            return _pattern.Matches(input, start, length);
        }

        public static InstancableFactory Wrap(Type type)
        {
            if (type.GetCustomAttribute<InstancableAttribute>() == null)
            {
                throw new Exception("No instancable attribute on " + type);
            }
            return new InstancableFactory(type, PatternFactory.Compile(type.GetCustomAttribute<InstancableAttribute>()!.Pattern));
        }
    }
}