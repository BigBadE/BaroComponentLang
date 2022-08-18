using System;

namespace Language.Patterns
{
    public interface IPatternPart
    {
        ParseResult<object> ParseWord(char[] buffer, int start, int length);
    }

    public class ParseResult<T>
    {
        public T Result;
        public ParseResultType Type;
        
    }
    public enum ParseResultType
    {
        Failed,
        Passed,
        Undetermined
    }
}