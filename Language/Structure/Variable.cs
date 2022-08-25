using System;
using System.Collections.Generic;
using Compiler.Components;
using Compiler.Structure;
using Language.Effects;
using Language.Expressions;
using Language.Util;

namespace Language.Structure
{
    [Instancable("var %name%[=%value%]")]
    public class Variable : Expression, IMainField
    {
        [Argument(0)] public string Name;
        [Argument(1, true)] public Effect? DefaultValue;

        public override object? Precompute() => DefaultValue?.Precompute() ?? null;
        
        protected override Connector CompileTo(Connector input, out GameComponent output)
        {
            output = new GameComponent(MiscComponents.MemoryComponent.Instance);
            input.ConnectTo(new Connector(output, output.Type.InputConnections()[0]));
            return new Connector(output, output.Type.OutputConnections()[0]);
        }

        public string ToString(bool dropVar)
        {
            if (DefaultValue == null)
            {
                return dropVar ? Name : "var " + Name;
            }

            return dropVar ? Name + " = " + DefaultValue : "var " + Name + " = " + DefaultValue;
        }

        public override string ToString()
        {
            if (DefaultValue == null)
            {
                return "var " + Name;
            }

            return "var " + Name + " = " + DefaultValue;
        }
    }


    [Instancable("%name%=%value%")]
    public class SetVariable : Expression
    {
        [Argument(0)] public string Name;
        [Argument(1)] public Effect Value;

        public override object? Precompute() => Value.Precompute() ?? null;

        protected override Connector CompileTo(Connector input, out GameComponent output)
        {
            output = new GameComponent(MiscComponents.MemoryComponent.Instance);
            input.ConnectTo(new Connector(output, output.Type.InputConnections()[0]));
            return new Connector(output, output.Type.OutputConnections()[0]);
        }

        public string ToString()
        {
            return Name + " = " + Value;
        }
    }
}