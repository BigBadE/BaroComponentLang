namespace Compiler.Components
{
    public class AndComponent : IComponent
    {
        public static readonly IComponent Instance = new AndComponent();
        
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2", "set_output"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "AndComponent";
    }
    
    public class EqualsComponent : IComponent
    {
        public static readonly IComponent Instance = new EqualsComponent();
        
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2", "set_output"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "EqualsComponent";
    }
    
    public class GreaterComponent : IComponent
    {
        public static readonly IComponent Instance = new GreaterComponent();
        
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2", "set_output"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "GreaterComponent";
    }
    
    public class NotComponent : IComponent
    {
        public static readonly IComponent Instance = new NotComponent();
        
        public string[] InputConnections() => new[] {"signal_in"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "NotComponent";
    }
    
    public class OrComponent : IComponent
    {
        public static readonly IComponent Instance = new OrComponent();
        
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2", "set_output"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "OrComponent";
    }
    
    public class XorComponent : IComponent
    {
        public static readonly IComponent Instance = new XorComponent();
        
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2", "set_output"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "XorComponent";
    }
    
    public class SignalCheckComponent : IComponent
    {
        public static readonly IComponent Instance = new SignalCheckComponent();
        
        public string[] InputConnections() => new[] {"signal_in", "set_output", "set_targetsignal"};

        public string[] OutputConnections() => new[] {"signal_out"};

        public override string ToString() => "SignalComponent";
    }
}