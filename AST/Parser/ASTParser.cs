using AST.Parser;
using AST.Tree;
using AST.Util;

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
                            state = ParserState.Method;
                        } else if (line.Contains("->"))
                        {
                            state = ParserState.Listener;
                        }
                        break;
                    case ParserState.Listener:
                        moveNext = true;
                        break;
                    case ParserState.Variable:
                        moveNext = true;
                        break;
                    case ParserState.Method:
                        moveNext = methodParser.ParseMethod(current, line);
                        break;
                }
            }
        }

        return current;
    }
}
