using System.Collections.Generic;
using Language.Listener;
using Language.Structure;

namespace AST.Tree
{
    public class ASTTree
    {
        public Dictionary<Listener, string> Listeners = new();
        public List<Method> Methods = new();
        public List<Variable> Variables = new();
    }
}