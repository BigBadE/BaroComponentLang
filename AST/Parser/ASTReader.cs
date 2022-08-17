namespace AST.Parser
{
    public class ASTReader : IASTReader
    {
        protected const int BufferSize = 2048 * 8;

        protected char[] Characters = new char[BufferSize];
        protected int Index;
            
        public char ReadNext()
        {
            return Characters[Index];
        }
    }
}