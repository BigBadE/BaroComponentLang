using System;
using System.Collections.Generic;
using Language.Expressions;
using Language.Expressions.Control;
using Language.Structure;
using Language.Util;

namespace AST.Parser
{
    public class MethodParser
    {
        [SubTypeList(typeof(Expression))] 
        public static List<InstancableFactory> Expressions;
        
        private readonly Method _method;
        private ControlExpression? _parent;
        
        public MethodParser(Method method)
        {
            _method = method;
        }
        
        public bool Parse(string line)
        {
            if (line.EndsWith("}"))
            {
                if (_parent == null)
                {
                    return true;
                }
                _parent = _parent.Parent;
            }
            
            Expression? found = null;
            ParseResult result = new ParseResult(-1);
            foreach (InstancableFactory expression in Expressions)
            {
                result = expression.Matches(line.ToCharArray(), 0, line.Length);
                if (result.Length == -1)
                {
                    continue;
                }
                
                found = expression.Instantiate<Expression>();
                found.Init(result.Values);
                break;
            }

            if (result.Length == -1)
            {
                throw new Exception("Unknown expression " + line);
            }

            if (_parent == null)
            {
                _method.Expressions.Add(found!);
            }
            else
            {
                _parent.Lines.Add(found!);
            }

            if (found! is not ControlExpression controlExpression)
            {
                return false;
            }
            
            controlExpression.Parent = _parent;
            _parent = controlExpression;

            return false;
        }
    }
}