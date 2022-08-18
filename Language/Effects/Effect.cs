using System;
using System.Collections.Generic;
using Language.Patterns;
using Language.Util;

namespace Language.Effects
{
    public abstract class Effect
    {
        [SubTypeList(typeof(Effect))]
        public static List<Type> Effects;

        public abstract int Args();

        public abstract object Precompute();

        public abstract Pattern Pattern();
        
        public static ParseResult<Effect> Parse(string effect, bool nullable = false)
        {
            
            return null;
        }
    }
}