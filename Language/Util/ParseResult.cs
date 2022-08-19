using System;
using System.Collections.Generic;

namespace Language.Util
{
    public struct ParseResult
    {
        public readonly int Length;
        public readonly List<object>? Values;

        public ParseResult(int length, object? value = null)
        {
            Length = length;
            Values = value == null ? null : new List<object> {value};
        }

        public ParseResult(int length, List<object> values)
        {
            Length = length;
            Values = values;
        }
    }
}