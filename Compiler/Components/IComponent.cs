namespace Compiler.Components
{
    public interface IComponent
    {
        public string[] InputConnections();
        
        public string[] OutputConnections();
    }
}