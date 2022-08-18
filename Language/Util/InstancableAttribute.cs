using System;
using System.Reflection;

namespace Language.Util
{
    [AttributeUsage(AttributeTargets.Class)]
    public class InstancableAttribute : Attribute
    {
        public string Name;

        public InstancableAttribute(string name)
        {
            Name = name;
        }
        
        public static T Construct<T>(Type type)
        {
            return (T) type.GetConstructor(BindingFlags.Default, Array.Empty<Type>())!
                .Invoke(Array.Empty<object>());
        }
    }
}