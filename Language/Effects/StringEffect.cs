using System.Collections.Generic;
using Language.Types;
using Language.Util;

namespace Language.Effects
{
    [Instancable("%string%")]
    public class StringEffect : Effect
    {
        [Argument(0)]
        private string _string;
        
        public override object Precompute() => _string;
        
        public override TypesEnum ReturnType() => TypesEnum.String;
    }
}