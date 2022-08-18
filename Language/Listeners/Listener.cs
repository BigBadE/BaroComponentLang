using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Reflection;
using Language.Util;

namespace Language.Listeners
{
    public abstract class Listener
    {
        [SubTypeList(typeof(Listener))]
        public static List<Type> Listeners;

        public ConnectionPin Pin { get; private set; }

        public abstract ConnectionPin? GetPin(string name);
        
        public static Listener Parse(string input)
        {
            string[] split = input.Split("-", 2);
            
            Listener target = InstancableAttribute.Construct<Listener>(
                Listeners.Find(expression => 
                    expression.GetCustomAttribute<InstancableAttribute>()?.Name == split[0].Trim()) ??
                throw new Exception("No device called " + split[0].Trim()));

            target.Pin = target.GetPin(split[1].Trim()) ?? 
                               throw new Exception("No pin called " + split[1].Trim());
            return target;
        }
    }
}