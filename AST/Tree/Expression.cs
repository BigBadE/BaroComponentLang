using System;
using System.Collections.Generic;
using AST.Util;

namespace AST.Tree
{
    public class Expression
    {
        [SubTypeList(typeof(Expression))]
        public static List<Type> Expressions;
        
        public static Expression? Parse(string line, bool nullable = false)
        {
            //TODO
            return null;
        }

        public static Expression? Wrap(Effect? effect)
        {
            //TODO
            return null;
        }
    }
}