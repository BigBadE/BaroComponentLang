using System.Collections.Generic;
using Language.Types;
using Language.Util;

namespace Language.Effects
{
    [Instancable("%number%")]
    public class NumberEffect : Effect
    {
        [Argument(0)]
        private float _number;

        public override object Precompute() => _number;
        
        public override TypesEnum ReturnType() => TypesEnum.Number;
    }
}