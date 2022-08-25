using System;

namespace Language.Util
{
    [AttributeUsage(AttributeTargets.Field)]
    public class ArgumentAttribute : Attribute
    {
        public readonly int Number;
        public readonly bool Nullable;

        public ArgumentAttribute(int number, bool nullable = false)
        {
            Number = number;
            Nullable = nullable;
        }
    }
}