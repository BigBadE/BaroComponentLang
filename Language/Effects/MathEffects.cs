using System.Collections.Generic;
using Language.Util;

namespace Language.Effects
{
    [Instancable("%value% + %value%")]
    public class AdditionEffect : Effect
    {
        private Effect first;
        private Effect second;

        public override object? Precompute()
        {
            if (first.Precompute() == null || second.Precompute() == null)
            {
                return null;
            }
            else
            {
                return first.Precompute() + second.Precompute();
            }
        } 

        public override void Init(List<object>? args)
        {
            first = (Effect) args![0];
            second = (Effect) args[1];
        }
    }
}