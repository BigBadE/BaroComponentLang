using System;
using System.Linq;
using Language.Types;
using Language.Util;

namespace Language.Effects
{
    public abstract class MathEffect : Effect
    {
        [Argument(0)] protected Effect First;
        [Argument(1)] protected Effect Second;
    }

    [Instancable("%value%+%value%")]
    public class AdditionEffect : MathEffect
    {
        public override TypesEnum ReturnType() => 
            First.ReturnType() == TypesEnum.String || Second.ReturnType() == TypesEnum.String
                ? TypesEnum.String
                : TypesEnum.Number;

        public override object? Precompute()
        {
            object? firstValue = First.Precompute(), secondValue = Second.Precompute();
            if (firstValue == null || secondValue == null)
            {
                return null;
            }
            if (ReturnType() == TypesEnum.String)
            {
                return (string) firstValue + (string) secondValue;
            }
            
            return (float) firstValue + (float) secondValue;
        }
    }

    [Instancable("%value%-%value%")]
    public class SubtractionEffect : MathEffect
    {
        public override TypesEnum ReturnType() => TypesEnum.Number;

        public override object? Precompute()
        {
            object? firstValue = First.Precompute(), secondValue = Second.Precompute();
            
            if (firstValue is not float firstNumber || secondValue is not float secondNumber)
            {
                return null;
            }

            return firstNumber - secondNumber;
        }
    }
    
    [Instancable("%value%*%value%")]
    public class MultiplicationEffect : MathEffect
    {
        public override TypesEnum ReturnType() => 
            First.ReturnType() == TypesEnum.String || Second.ReturnType() == TypesEnum.String
                ? TypesEnum.String
                : TypesEnum.Number;

        public override object? Precompute()
        {
            object? firstValue = First.Precompute(), secondValue = Second.Precompute();
            if (firstValue == null || secondValue == null)
            {
                return null;
            }

            switch (firstValue)
            {
                case string firstString:
                    if (secondValue is float secondNumber)
                    {
                        return string.Concat(Enumerable.Repeat(firstString, (int) secondNumber));
                    }
                    break;
                case float firstNumber:
                    if (secondValue is float secondFloat)
                    {
                        return firstNumber * secondFloat;
                    }
                    break;
            }

            return null;
        }
    }
    
    [Instancable("%value%/%value%")]
    public class DivisionEffect : MathEffect
    {
        public override TypesEnum ReturnType() => TypesEnum.Number;

        public override object? Precompute()
        {
            object? firstValue = First.Precompute(), secondValue = Second.Precompute();
            
            if (firstValue is not float firstNumber || secondValue is not float secondNumber)
            {
                return null;
            }

            return firstNumber / secondNumber;
        }
    }
    
    [Instancable("%value%\\%%value%")]
    public class ModuloEffect : MathEffect
    {
        public override TypesEnum ReturnType() => TypesEnum.Number;

        public override object? Precompute()
        {
            object? firstValue = First.Precompute(), secondValue = Second.Precompute();
            
            if (firstValue is not float firstNumber || secondValue is not float secondNumber)
            {
                return null;
            }

            return firstNumber % secondNumber;
        }
    }
    
    [Instancable("%value%^%value%")]
    public class PowerEffect : MathEffect
    {
        public override TypesEnum ReturnType() => TypesEnum.Number;

        public override object? Precompute()
        {
            object? firstValue = First.Precompute(), secondValue = Second.Precompute();
            
            if (firstValue is not float firstNumber || secondValue is not float secondNumber)
            {
                return null;
            }

            return Math.Pow(firstNumber, secondNumber);
        }
    }
    
    [Instancable("(%value%)0")]
    public class ParenthesisEffect : Effect
    {
        [Argument(0)] public Effect Value;
        
        public override TypesEnum ReturnType() => Value.ReturnType();

        public override object? Precompute() => Value.Precompute();
    }
}