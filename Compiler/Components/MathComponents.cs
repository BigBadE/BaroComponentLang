namespace Compiler.Components
{
    public class AbsComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class AdderComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class CeilComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class DivideComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class ExponentiationComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class FactorialComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class FloorComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class ModuloComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class MultiplyComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class RoundComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class SquareRootComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
    
    public class SubtractComponent : IComponent
    {
        public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2"};

        public string[] OutputConnections() => new[] {"signal_out"};
    }
}