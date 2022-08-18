using System.Collections.Generic;

namespace AST.Tree
{
    public class ASTTree
    {
        public Dictionary<Listener, string> Listeners = new();
        public List<Method> Methods = new();
    }
}