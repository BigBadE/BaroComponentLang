using Compiler.Structure;

namespace Compiler.Components
{
    public class MiscComponents
    {
        public class ColorComponent : IComponent
        {
            public static readonly IComponent Instance = new ColorComponent();
            
            public string[] InputConnections() => new[] {"signal_r", "signal_g", "signal_b", "signal_a"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class DelayComponent : IComponent
        {
            public static readonly IComponent Instance = new DelayComponent();
            
            public string[] InputConnections() => new[] {"signal_in", "set_delay"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class MemoryComponent : IComponent
        {
            public static readonly IComponent Instance = new MemoryComponent();
            
            public string[] InputConnections() => new[] {"signal_in", "lock_state"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class OscillatorComponent : IComponent
        {
            public static readonly IComponent Instance = new OscillatorComponent();
            
            public string[] InputConnections() => new[] {"set_frequency", "set_outputtype"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class RelayComponent : IComponent
        {
            public static readonly IComponent Instance = new RelayComponent();
            
            public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2", "toggle_state", "set_state"};

            public string[] OutputConnections() => new[] {"signal_out_1", "signal_out_2", "state_out", "load_value_out", "power_value_out"};
        }
        
        public class WifiComponent : IComponent
        {
            public static readonly IComponent Instance = new WifiComponent();
            
            public string[] InputConnections() => new[] {"signal_in", "set_channel", "signal_out"};

            public string[] OutputConnections() => new[] {"signal_in", "signal_out"};
        }
        
        public class NoOperationComponent : IComponent
        {
            public static readonly IComponent Instance = new NoOperationComponent();
            public static readonly GameComponent Component = new GameComponent(Instance);
            public static readonly Connector Connector = new Connector(Component, "null");
            public string[] InputConnections() => new[] {"null"};

            public string[] OutputConnections() => new[] {"null"};
        }
    }
}