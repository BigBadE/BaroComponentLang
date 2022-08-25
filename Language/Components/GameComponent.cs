using System.Collections.Generic;
using Compiler.Components;

namespace Compiler.Structure
{
    public class GameComponent
    {
        public readonly IComponent Type;
        public Dictionary<Connector, List<Connector>> output = new();

        public GameComponent(IComponent type)
        {
            Type = type;
        }

        public void AddOutput(Connector pin, Connector outgoing)
        {
            if (output.TryGetValue(pin, out List<Connector>? outgoingConnections))
            {
                outgoingConnections.Add(outgoing);
            }
            else
            {
                output.Add(pin, new List<Connector> { outgoing });
            }
        }
    }

    public struct Connector
    {
        public readonly string Connection;
        public readonly GameComponent Component;
        public object value;
        
        public Connector(GameComponent component, string connection)
        {
            Connection = connection;
            Component = component;
            value = 1;
        }

        public void ConnectTo(Connector target)
        {
            Component.AddOutput(this, target);
        }
    }
}