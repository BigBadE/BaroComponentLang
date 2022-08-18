using System.Collections.Generic;
using Language.Listeners;
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