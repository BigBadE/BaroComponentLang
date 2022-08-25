using System;
using System.Collections.Generic;
using System.Linq;
using AST.Tree;
using Compiler.Components;
using Compiler.Structure;
using Language.Expressions;
using Language.Listener;
using Language.Structure;

namespace Compiler
{
    public class Compiler
    {
        //Returns all components with no inputs, which can be followed to find all components.
        public List<GameComponent> Compile(ASTTree tree)
        {
            List<Method> methodPool = new();
            List<GameComponent> output = new();
            foreach (Listener listener in tree.Listeners)
            {
                Method found = tree.Methods.Find(method => method.Name == listener.method) ?? 
                               throw new Exception("Unknown method " + listener.method + " for listener");
                if (found.Args.Length > 1)
                {
                    throw new Exception("Listener points to method " + found.Name + " with arguments");
                }
                
                if (methodPool.Contains(found))
                {
                    continue;
                }

                GameComponent start = new(listener.device);

                CompileMethod(found, new Connector(start, listener.connector));
                output.Add(start);
                methodPool.Add(found);
            }

            return output;
        }

        private void CompileMethod(Method target, Connector input)
        {
            foreach (Expression expression in target.Expressions)
            {
                input = expression.Compile(input);
            }
        }
    }
}