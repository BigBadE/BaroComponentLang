using Language.Effects;

namespace Language.Expressions
{
    public class DroppedEffect : Expression
    {
        private Effect _effect;
        
        public DroppedEffect(Effect effect)
        {
            _effect = effect;
        }
    }
}