using System;
using System.Collections.Generic;
using System.Reflection;
using AST.Util;

namespace AST.Tree
{
    public abstract class Listener
    {
        [SubTypeList(typeof(Listener))]
        public static List<Type> Listeners;

        public ConnectionPin pin;

        public abstract ConnectionPin? GetPin(string name);
        
        public static Listener Parse(string input)
        {
            string[] split = input.Split("-", 2);
            
            Listener target = InstancableAttribute.Construct<Listener>(
                Listeners.Find(expression => 
                    expression.GetCustomAttribute<InstancableAttribute>()?.name == split[0].Trim()) ??
                throw new Exception("No device called " + split[0].Trim()));

            target.pin = target.GetPin(split[1].Trim()) ?? throw new Exception("No pin called " + split[1].Trim());
            return target;
        }
    }
}