using System.Collections.Generic;
using System.IO;

namespace AST.Parser
{
    public class ASTReader : IASTReader
    {
        private string _file;
        
        public ASTReader(string file)
        {
            _file = file;
        }
        
        public IEnumerable<string> ReadLines()
        {
            foreach (string line in File.ReadLines(_file))
            {
                yield return line;
            }
        }
    }
}