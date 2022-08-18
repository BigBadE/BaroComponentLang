using System.Collections.Generic;

namespace AST.Tree
{
    public class Method : IVariableOwner
    {
        public string Name;
        public List<Expression> Expressions = new();
    }
}