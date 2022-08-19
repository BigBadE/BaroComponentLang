using System.Collections.Generic;
using Language.Util;

namespace Language.Effects
{
    [Instancable("%number%")]
    public class NumberEffect : Effect
    {
        private float _number;

        public override object Precompute() => _number;

        public override void Init(List<object>? args)
        {
            _number = (float) args![0];
        }
    }
}