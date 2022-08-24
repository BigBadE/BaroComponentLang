namespace Compiler.Components
{
    public class TrigComponents
    {
        public class AcosComponent : IComponent
        {
            public static readonly IComponent Instance = new AcosComponent();
            
            public string[] InputConnections() => new[] {"signal_in"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class AsinComponent : IComponent
        {
            public static readonly IComponent Instance = new AsinComponent();
            
            public string[] InputConnections() => new[] {"signal_in"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class AtanComponent : IComponent
        {
            public static readonly IComponent Instance = new AtanComponent();
            
            public string[] InputConnections() => new[] {"signal_in"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class CosComponent : IComponent
        {
            public static readonly IComponent Instance = new CosComponent();
            
            public string[] InputConnections() => new[] {"signal_in"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class SinComponent : IComponent
        {
            public static readonly IComponent Instance = new SinComponent();
            
            public string[] InputConnections() => new[] {"signal_in"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class TanComponent : IComponent
        {
            public static readonly IComponent Instance = new TanComponent();
            
            public string[] InputConnections() => new[] {"signal_in"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
    }
}