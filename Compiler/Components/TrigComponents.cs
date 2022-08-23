namespace Compiler.Components
{
    public class TrigComponents
    {
        public class AcosComponent : IComponent
        {
            public string[] InputConnections() => new[] {"signal_in"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class AsinComponent : IComponent
        {
            public string[] InputConnections() => new[] {"signal_in"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class AtanComponent : IComponent
        {
            public string[] InputConnections() => new[] {"signal_in"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class CosComponent : IComponent
        {
            public string[] InputConnections() => new[] {"signal_in"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class SinComponent : IComponent
        {
            public string[] InputConnections() => new[] {"signal_in"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class TanComponent : IComponent
        {
            public string[] InputConnections() => new[] {"signal_in"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
    }
}