using System;
using System.Collections.Generic;
using AST.Parser;
using AST.Tree;
using Language.Listener;
using Language.Structure;
using Language.Util;

public class ASTParser
{
    [SubTypeList(typeof(IMainField))] 
    public static List<InstancableFactory> MainFields;
    
    public ASTTree Parse(ASTReader reader)
    {
        if (!SubTypeListAttribute.IsInited())
        {
            SubTypeListAttribute.InitSubTypeLists();
        }
        
        ASTTree current = new();
        MethodParser? methodParser = null;
        foreach (string rawLine in reader.ReadLines())
        {
            string line = rawLine.Trim();
            if (line.Length == 0)
            {
                continue;
            }

            if (methodParser != null)
            {
                if (methodParser.Parse(rawLine))
                {
                    methodParser = null;
                }
                else
                {
                    continue;
                }
            }

            IMainField? found = null;
            ParseResult result = new ParseResult(-1);
            foreach (InstancableFactory mainField in MainFields)
            {
                result = mainField.Matches(rawLine.ToCharArray(), 0, rawLine.Length);
                if (result.Length == rawLine.Length)
                {
                    found = mainField.Instantiate<IMainField>();
                    break;
                }
            }

            switch (found)
            {
                case null:
                    throw new Exception("Unknown line " + rawLine);
                case Variable variable:
                    variable.Init(result.Values);
                    current.Variables.Add(variable);
                    break;
                case Method method:
                    methodParser = new MethodParser(method);
                    break;
                case Listener listener:
                    listener.Init(result.Values);
                    current.Listeners.Add(listener, (string) result.Values[2]);
                    break;
            }
        }

        return current;
    }
}
