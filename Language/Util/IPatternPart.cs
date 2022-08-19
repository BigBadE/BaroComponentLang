namespace Language.Util
{
    public interface IPatternPart
    {
        public ParseResult Matches(char[] input, int start);
    }
}