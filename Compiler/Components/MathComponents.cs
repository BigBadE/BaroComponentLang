namespace Compiler.Components
{
    public class AbsComponent : IComponent
    {
        public static readonly IComponent Instance = new AbsComponent();
        
        public string[] InputConnections() => new[] {"signal_in"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "AbsComponent";
    }
    
    public class AdderComponent : IComponent
    {
        public static readonly IComponent Instance = new AbsComponent();
        
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "AdderComponent";
    }
    
    public class CeilComponent : IComponent
    {
        public static readonly IComponent Instance = new CeilComponent();
        
        public string[] InputConnections() => new[] {"signal_in"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "CeilComponent";
    }
    
    public class DivideComponent : IComponent
    {
        public static readonly IComponent Instance = new DivideComponent();
        
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "DivideComponent";
    }
    
    public class ExponentiationComponent : IComponent
    {
        public static readonly IComponent Instance = new ExponentiationComponent();
        
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "ExponentiationComponent";
    }
    
    public class FactorialComponent : IComponent
    {
        public static readonly IComponent Instance = new FactorialComponent();
        
        public string[] InputConnections() => new[] {"signal_in"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "FactorialComponent";
    }
    
    public class FloorComponent : IComponent
    {
        public static readonly IComponent Instance = new FloorComponent();
        
        public string[] InputConnections() => new[] {"signal_in"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "FloorComponent";
    }
    
    public class ModuloComponent : IComponent
    {
        public static readonly IComponent Instance = new ModuloComponent();
        
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "ModuloComponent";
    }
    
    public class MultiplyComponent : IComponent
    {
        public static readonly IComponent Instance = new MultiplyComponent();
        
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "MultiplyComponent";
    }
    
    public class RoundComponent : IComponent
    {
        public static readonly IComponent Instance = new RoundComponent();
        
        public string[] InputConnections() => new[] {"signal_in"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "RoundComponent";
    }
    
    public class SquareRootComponent : IComponent
    {
        public static readonly IComponent Instance = new SquareRootComponent();
        
        public string[] InputConnections() => new[] {"signal_in"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "SquareRootComponent";
    }
    
    public class SubtractComponent : IComponent
    {
        public static readonly IComponent Instance = new SubtractComponent();
        
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2"};

        public string[] OutputConnections() => new[] {"signal_out"};
        
        public override string ToString() => "SubtractComponent";
    }
}