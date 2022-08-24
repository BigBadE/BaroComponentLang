using System;
using System.Collections.Generic;
using System.Linq;
using Compiler.Components;
using Language.Structure;
using Language.Util;

namespace Language.Listener
{
    [Instancable("%device%_%name%->%name%")]
    public class Listener : IMainField
    {
        [Argument(0)] public IComponent device;
        [Argument(1)] public string connector;
        [Argument(2)] public string method;

        public override string ToString()
        {
            return device + "_" + connector + " -> " + method;
        }
    }
}