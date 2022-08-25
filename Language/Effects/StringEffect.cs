using System.Collections.Generic;
using Compiler.Components;
using Compiler.Structure;
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
        
        protected override Connector CompileTo(Connector input, out GameComponent? component)
        {
            component = new GameComponent(MiscComponents.MemoryComponent.Instance);
            return new Connector(component, component.Type.OutputConnections()[0]);
        }
        
        public override TypesEnum ReturnType() => TypesEnum.String;
    }
}