using System;
using System.Collections.Generic;
using AST.Util;

namespace AST.Tree
{
    public abstract class Effect
    {
        [SubTypeList(typeof(Effect))]
        public static List<Type> Effects;

        public abstract int Args();

        public abstract object Precompute();
        
        public static Effect? Parse(string effect, bool nullable = false)
        {
            //TODO
            return null;
        }
    }
}