namespace Compiler.Components
{
    public class MiscComponents
    {
        public class ColorComponent : IComponent
        {
            public string[] InputConnections() => new[] {"signal_r", "signal_g", "signal_b", "signal_a"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class DelayComponent : IComponent
        {
            public string[] InputConnections() => new[] {"signal_in", "set_delay"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class MemoryComponent : IComponent
        {
            public string[] InputConnections() => new[] {"signal_in", "lock_state"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class OscillatorComponent : IComponent
        {
            public string[] InputConnections() => new[] {"set_frequency", "set_outputtype"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class RelayComponent : IComponent
        {
            public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2", "toggle_state", "set_state"};

            public string[] OutputConnections() => new[] {"signal_out_1", "signal_out_2", "state_out", "load_value_out", "power_value_out"};
        }
        
        public class WifiComponent : IComponent
        {
            public string[] InputConnections() => new[] {"signal_in", "set_channel", "signal_out"};

            public string[] OutputConnections() => new[] {"signal_in", "signal_out"};
        }
    }
}