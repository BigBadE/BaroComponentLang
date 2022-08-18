using System.Collections.Generic;

namespace AST.Tree
{
    public class Method
    {
        public string Name;
        public List<Expression> Expressions = new();
    }
}