using System;
using System.Reflection;

namespace AST.Util
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InstancableAttribute : Attribute
    {
        public string name;

        public static T Construct<T>(Type type)
        {
            return (T) type.GetConstructor(BindingFlags.Default, Array.Empty<Type>())!
                .Invoke(Array.Empty<object>());
        }
    }
}