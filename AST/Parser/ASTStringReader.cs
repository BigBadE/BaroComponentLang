using System.Collections.Generic;

namespace AST.Parser
{
    public class ASTStringReader : IASTReader
    {
        private string _string;

        public ASTStringReader(string found)
        {
            _string = found;
        }
        
        public IEnumerable<string> ReadLines()
        {
            foreach (string line in _string.Split('\n'))
            {
                yield return line;
            }
        }
    }
}