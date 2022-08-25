using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using AST.Parser;
using AST.Tree;
using Language.Listener;
using Language.Structure;
using Language.Util;

public class ASTParser
{
    [SubTypeList(typeof(IMainField))] 
    public static List<InstancableFactory> MainFields;
    
    public ASTTree Parse(IASTReader reader)
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
                    Init(variable, result.Values);
                    current.Variables.Add(variable);
                    break;
                case Method method:
                    Init(method, result.Values);
                    methodParser = new MethodParser(method);
                    break;
                case Listener listener:
                    Init(listener, result.Values);
                    current.Listeners.Add(listener);
                    break;
            }
        }

        return current;
    }

    public static void Init(object target, List<object>? values)
    {
        if (values == null)
        {
            if (target.GetType().GetFields().Any(field => field.GetCustomAttribute<ArgumentAttribute>() != null))
            {
                throw new Exception("No arguments for " + target.GetType());
            }

            return;
        }
        
        int toUse = values.Count;
        foreach (FieldInfo field in target.GetType().GetFields())
        {
            ArgumentAttribute? argumentAttribute = field.GetCustomAttribute<ArgumentAttribute>();
            if (argumentAttribute == null)
            {
                continue;
            }

            if (argumentAttribute.Number > values.Count)
            {
                if (!argumentAttribute.Nullable)
                {
                    throw new Exception("Null value for argument field " + field.Name);
                }
                return;
            }

            toUse--;
            field.SetValue(target, values[argumentAttribute.Number]);
        }

        if (toUse != 0)
        {
            throw new Exception("Unused argument for type " + target.GetType());
        }
    }
}
