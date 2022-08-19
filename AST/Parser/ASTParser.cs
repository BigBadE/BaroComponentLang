using AST.Parser;
using AST.Tree;
using Language.Util;

public class ASTParser
{
    public ASTTree Parse(ASTReader reader)
    {
        if (!SubTypeListAttribute.IsInited())
        {
            SubTypeListAttribute.InitSubTypeLists();
        }
        
        ASTTree current = new();
        foreach (string rawLine in reader.ReadLines())
        {
            string line = rawLine.Trim();
            if (line.Length == 0)
            {
                continue;
            }
        }

        return current;
    }
}
