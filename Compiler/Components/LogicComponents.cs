namespace Compiler.Components
{
    public class AndComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2", "set_output"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class EqualsComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2", "set_output"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class GreaterComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2", "set_output"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class NotComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class OrComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2", "set_output"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class XorComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2", "set_output"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class SignalCheckComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in", "set_output", "set_targetsignal"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
}