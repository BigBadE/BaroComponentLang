using Compiler.Components;
using Compiler.Structure;
using Language.Effects;

namespace Language.Expressions
{
    public abstract class Expression
    {
        protected GameComponent? Component;
        
        public abstract object? Precompute();

        public Connector Compile(Connector input)
        {
            if (Component != null)
            {
                return PrecomputedConstructor(input);
            }

            Connector found = CompileTo(input, out var component);
            Component = component;
            return found;
        }

        protected abstract Connector CompileTo(Connector input, out GameComponent? component);

        protected virtual Connector PrecomputedConstructor(Connector input)
        {
            return new Connector(Component!, Component!.Type.InputConnections()[0]);
        }

        protected bool? HandlePrecomputation(Connector input, Effect first, Effect second)
        {
            object? firstValue = first.Precompute();
            object? secondValue = second.Precompute();

            if (firstValue != null)
            {
                input.value = firstValue;
                return true;
            }

            if (secondValue == null)
            {
                return null;
            }
            
            input.value = secondValue;
            return false;
        }

        protected GameComponent TwoValueCompilation(Connector input, Effect first, Effect second, IComponent component)
        {
            GameComponent output;
            switch (HandlePrecomputation(input, first, second))
            {
                case true:
                    output = new GameComponent(component);
                    input.ConnectTo(new Connector(output, output.Type.InputConnections()[0]));
                    second.Compile(new Connector(output, output.Type.InputConnections()[1]));
                    break;
                case false:
                    output = new GameComponent(component);
                    input.ConnectTo(new Connector(output, output.Type.InputConnections()[0]));
                    first.Compile(new Connector(output, output.Type.InputConnections()[1]));
                    break;
                case null:
                    output = new GameComponent(OrComponent.Instance);
                    GameComponent targetComponent = new(component);
                    first.Compile(new Connector(targetComponent, targetComponent.Type.InputConnections()[0]));
                    second.Compile(new Connector(targetComponent, targetComponent.Type.InputConnections()[1]));
                    targetComponent.AddOutput(new Connector(targetComponent, targetComponent.Type.OutputConnections()[0]), 
                        new Connector(output, output.Type.InputConnections()[0]));
                    input.ConnectTo(new Connector(output, output.Type.InputConnections()[1]));
                    break;
            }

            return output;
        }
    }
}