using System;
using System.Linq;
using Compiler.Components;
using Compiler.Structure;
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

        protected override Connector PrecomputedConstructor(Connector input)
        {
            HandlePrecomputation(input, First, Second);
            return base.PrecomputedConstructor(input);
        }

        protected override Connector CompileTo(Connector input, out GameComponent output)
        {
            output = TwoValueCompilation(input, First, Second, AdderComponent.Instance);
            return new Connector(output, output.Type.OutputConnections()[0]);
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
        
        protected override Connector PrecomputedConstructor(Connector input)
        {
            HandlePrecomputation(input, First, Second);
            return base.PrecomputedConstructor(input);
        }

        protected override Connector CompileTo(Connector input, out GameComponent output)
        {
            output = TwoValueCompilation(input, First, Second, SubtractComponent.Instance);
            return new Connector(output, output.Type.OutputConnections()[0]);
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
        
        protected override Connector PrecomputedConstructor(Connector input)
        {
            HandlePrecomputation(input, First, Second);
            return base.PrecomputedConstructor(input);
        }

        protected override Connector CompileTo(Connector input, out GameComponent output)
        {
            output = TwoValueCompilation(input, First, Second, MultiplyComponent.Instance);
            return new Connector(output, output.Type.OutputConnections()[0]);
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
        
        protected override Connector PrecomputedConstructor(Connector input)
        {
            HandlePrecomputation(input, First, Second);
            return base.PrecomputedConstructor(input);
        }

        protected override Connector CompileTo(Connector input, out GameComponent output)
        {
            output = TwoValueCompilation(input, First, Second, DivideComponent.Instance);
            return new Connector(output, output.Type.OutputConnections()[0]);
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
        
        protected override Connector PrecomputedConstructor(Connector input)
        {
            HandlePrecomputation(input, First, Second);
            return base.PrecomputedConstructor(input);
        }

        protected override Connector CompileTo(Connector input, out GameComponent output)
        {
            output = TwoValueCompilation(input, First, Second, ModuloComponent.Instance);
            return new Connector(output, output.Type.OutputConnections()[0]);
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
        
        protected override Connector PrecomputedConstructor(Connector input)
        {
            HandlePrecomputation(input, First, Second);
            return base.PrecomputedConstructor(input);
        }

        protected override Connector CompileTo(Connector input, out GameComponent output)
        {
            output = TwoValueCompilation(input, First, Second, ExponentiationComponent.Instance);
            return new Connector(output, output.Type.OutputConnections()[0]);
        }
    }

    [Instancable("(%value%)0")]
    public class ParenthesisEffect : Effect
    {
        [Argument(0)] public Effect Value;

        public override TypesEnum ReturnType() => Value.ReturnType();

        public override object? Precompute() => Value.Precompute();
        
        protected override Connector CompileTo(Connector input, out GameComponent? component)
        {
            component = null;
            return Value.Compile(input);
        }
    }
}