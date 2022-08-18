using System;
using System.Collections.Generic;
using Language.Effects;
using Language.Util;

namespace Language.Expressions
{
    public abstract class Expression
    {
        [SubTypeList(typeof(Expression))]
        public static List<Type> Expressions;
        
        public static Expression? Parse(string line, bool nullable = false)
        {
            Expression? found = null;

            ExpressionParserState state = ExpressionParserState.Starting;
            for(int i = 0; i < line.Length; i++)
            {
                char character = line[i];
                switch (state)
                {
                    case ExpressionParserState.Starting:
                        switch (character)
                        {
                            case >= '0' and <= '9':
                                state = ExpressionParserState.Number;
                                i--;
                                break;
                            case '"':
                                state = ExpressionParserState.String;
                                break;
                            case >= 'A' and <= 'Z' or >= 'a' and <= 'z':
                                state = ExpressionParserState.Variable;
                                i--;
                                break;
                            default:
                                throw new Exception("Illegal character " + character + " (" + i + ") in " + line);
                        }
                        break;
                    case ExpressionParserState.Number:
                        
                        break;
                    case ExpressionParserState.String:
                        break;
                    case ExpressionParserState.Variable:
                        break;
                    case ExpressionParserState.Method:
                        break;
                    case ExpressionParserState.Arguments:
                        break;
                }
            }
            
            if (found == null && !nullable)
            {
                throw new Exception("No expression found for line " + line);
            }
            return found;
        }

        public static Expression? Wrap(Effect? effect)
        {
            return effect == null ? null : new DroppedEffect(effect);
        }
    }
}