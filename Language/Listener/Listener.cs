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
        private Device _device;
        private string _connector;

        private string _target;
        
        public void Init(List<object> args)
        {
            _device = (Device) args[0];
            _connector = (string) args[1];

            if (!_device.Connections().Contains(_connector))
            {
                throw new Exception("Unknown connector " + _connector + " in device " + _device);
            }

            _target = (string) args[2];
        }
    }
}