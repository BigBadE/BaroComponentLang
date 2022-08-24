namespace Compiler.Components
{
    public class StringComponents
    {
        public class RegexComponent : IComponent
        {
            public static readonly IComponent Instance = new RegexComponent();
            
            public string[] InputConnections() => new[] {"signal_in_1", "set_output"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
        
        public class ConcatinationComponent : IComponent
        {
            public static readonly IComponent Instance = new ConcatinationComponent();
            
            public string[] InputConnections() => new[] {"signal_in_1", "signal_in_2"};

            public string[] OutputConnections() => new[] {"signal_out"};
        }
    }
}