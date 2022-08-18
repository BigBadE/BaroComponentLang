using System;
using System.Collections.Generic;
using AST.Util;

namespace AST.Tree
{
    public class Effect
    {
        [SubTypeList(typeof(Effect))]
        public static List<Type> Effects;

        public static Effect? Parse(string effect, bool nullable = false)
        {
            //TODO
            return null;
        }
    }
}