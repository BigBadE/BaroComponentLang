using AST.Parser;
using AST.Tree;
using Language.Listeners;
using Language.Structure;
using Language.Util;

public class ASTParser
{
    public ASTTree Parse(ASTReader reader)
    {
        if (!SubTypeListAttribute.IsInited())
        {
            SubTypeListAttribute.InitSubTypeLists();
        }
        
        ParserState state = ParserState.Main;
        ASTTree current = new();
        MethodParser methodParser = new();
        foreach (string rawLine in reader.ReadLines())
        {
            string line = rawLine.Trim();
            if (line.Length == 0)
            {
                continue;
            }

            bool moveNext = false;
            while (!moveNext)
            {
                switch (state)
                {
                    case ParserState.Main:
                        if (line.StartsWith("var "))
                        {
                            state = ParserState.Variable;
                        } else if (line.StartsWith("func "))
                        {
                            string[] splitMethod = line.Substring(4).Split("(", 2);
                            
                            methodParser.Start(splitMethod[0].Trim(), 
                                splitMethod[1].Trim()[..splitMethod[1].LastIndexOf(')')]);
                            state = ParserState.Method;
                        } else if (line.Contains("->"))
                        {
                            state = ParserState.Listener;
                        }
                        break;
                    case ParserState.Listener:
                        string[] split = line.Split("->");
                        current.Listeners.Add(Listener.Parse(split[0].Trim()), split[1].Trim());
                        moveNext = true;
                        break;
                    case ParserState.Variable:
                        string[] splitVar = line.Split("=");
                        current.Variables.Add(Variable.Parse(null, splitVar[0].Trim(), splitVar[1].Trim()));
                        moveNext = true;
                        break;
                    case ParserState.Method:
                        if (methodParser.ParseMethod(current, line))
                        {
                            state = ParserState.Main;
                        }
                        moveNext = true;
                        break;
                }
            }
        }

        return current;
    }
}
