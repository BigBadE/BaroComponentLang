using System;
using System.Collections.Generic;
using System.Linq;
using Language.Structure;
using Language.Util;

namespace Language.Listener
{
    [Instancable("%device%_%name% -> %name%")]
    public class Listener : IMainField
    {
        public Device Device { get; private set; }
        public string Connector { get; private set; }

        public string Target { get; private set; }
        
        public void Init(List<object> args)
        {
            Device = (Device) args[0];
            Connector = (string) args[1];

            if (!Device.Connections().Contains(Connector))
            {
                throw new Exception("Unknown connector " + Connector + " in device " + Device);
            }

            Target = (string) args[2];
        }
    }
}