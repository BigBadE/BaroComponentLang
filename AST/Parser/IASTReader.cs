using System.Collections.Generic;

namespace AST.Parser
{
    public interface IASTReader
    {
        IEnumerable<string> ReadLines();
    }
}