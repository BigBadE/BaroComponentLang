namespace Compiler.Components
{
    public interface IComponent
    {
        public static readonly IComponent[] Components =
        {
            AndComponent.Instance, EqualsComponent.Instance, GreaterComponent.Instance, NotComponent.Instance,
            OrComponent.Instance, StringComponents.RegexComponent.Instance, SignalCheckComponent.Instance,
            XorComponent.Instance, AbsComponent.Instance, AdderComponent.Instance, CeilComponent.Instance,
            DivideComponent.Instance, ExponentiationComponent.Instance, FactorialComponent.Instance,
            FloorComponent.Instance, ModuloComponent.Instance, MultiplyComponent.Instance, RoundComponent.Instance,
            SquareRootComponent.Instance, SubtractComponent.Instance, TrigComponents.AcosComponent.Instance,
            TrigComponents.AsinComponent.Instance, TrigComponents.AtanComponent.Instance,
            TrigComponents.CosComponent.Instance, TrigComponents.SinComponent.Instance,
            TrigComponents.TanComponent.Instance, MiscComponents.ColorComponent.Instance,
            StringComponents.ConcatinationComponent.Instance, MiscComponents.DelayComponent.Instance,
            MiscComponents.MemoryComponent.Instance, MiscComponents.OscillatorComponent.Instance,
            MiscComponents.RelayComponent.Instance, MiscComponents.WifiComponent.Instance
        };

        public string[] InputConnections();

        public string[] OutputConnections();
    }
}