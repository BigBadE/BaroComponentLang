﻿using System;
using System.Collections.Generic;
using Language.Effects;
using Language.Expressions;
using Language.Util;

namespace AST.Pattern
{
    public class ValuePatternPart : IPatternPart
    {
        [SubTypeList(typeof(Effect))]
        public static List<ExpressionFactory> Expressions;

        public ParseResult Matches(char[] input, int start)
        {
            int lowest = int.MaxValue;
            ExpressionFactory? lowestFactory = null;
            foreach (ExpressionFactory expression in Expressions)
            {
                int length = expression.Matches(input, start).Length;
                if (length > lowest)
                {
                    continue;
                }
                
                lowest = length;
                lowestFactory = expression;
            }

            return lowest == int.MaxValue ? new ParseResult(-1) : new ParseResult(lowest, lowestFactory);
        }
    }
}