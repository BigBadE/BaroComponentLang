﻿using AST.Tree;
using Language.Effects;
using Language.Expressions;
using Language.Expressions.Control;
using Language.Structure;

namespace AST.Parser
{
    public class MethodParser
    {
        private ControlExpression? _parent;
        private Method _method;

        public void Start(string name, string args)
        {
            _method = Method.Parse(name, args);
            _parent = null;
        }
        
        public bool ParseMethod(ASTTree current, string line)
        {
            if (line.EndsWith("}"))
            {
                if (_parent == null)
                {
                    current.Methods.Add(_method);
                    return true;
                }

                AddLine(_parent);
                _parent = _parent.Parent;
            }
            else if(line.EndsWith("{"))
            {
                string[] split = line.Split("(", 2);
                string name = split[0];
                string args = split[1][..^1];
                _parent = ControlExpression.Parse(name, args, _parent);
            }
            else
            {
                AddLine(Expression.Parse(line, true) ?? Expression.Wrap(Effect.Parse(line))!);
            }
            return false;
        }

        private void AddLine(Expression line)
        {
            if (_parent == null)
            {
                _method.Expressions.Add(line);
            }
            else
            {
                _parent.Lines.Add(line);
            }
        }
    }
}