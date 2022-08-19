using System.Collections.Generic;
using Language.Util;

namespace Language.Effects
{
    [Instancable("%string%")]
    public class StringEffect : Effect
    {
        private string _string;
        
        public override object Precompute() => _string;

        public override void Init(List<object>? args)
        {
            _string = (string) args![0];
        }
    }
}