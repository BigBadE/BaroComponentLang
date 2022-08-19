using System;
using System.Reflection;
using AST.Util;
using Language.Expressions;

namespace Language.Util
{
    public class ExpressionFactory
    {
        private Type _type;
        private Pattern _pattern;

        public ExpressionFactory(Type type, Pattern pattern)
        {
            _type = type;
            _pattern = pattern;
        }

        public Expression GetExpression()
        {
            return (Expression) _type.GetConstructor(BindingFlags.Default, Array.Empty<Type>())!
                .Invoke(Array.Empty<object>());
        }

        public ParseResult Matches(char[] input, int start)
        {
            return _pattern.Matches(input, start);
        }

        public static ExpressionFactory Wrap(Type type)
        {
            return new ExpressionFactory(type, PatternFactory.Compile(type.GetCustomAttribute<InstancableAttribute>()!.Pattern));
        }
    }
}