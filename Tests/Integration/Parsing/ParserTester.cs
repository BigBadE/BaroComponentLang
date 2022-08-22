using AST.Parser;
using NUnit.Framework;

namespace Tests.Integration.Patterns
{
    [TestFixture]
    public class ParserTester
    {
        private ASTParser _parser = new ASTParser();
        
        [Test]
        public void ParserTest()
        {
            Test(@"var test = 12
func testing() {
var test2 = ""string""
}");
        }

        private void Test(string input)
        {
            Assert.AreEqual(_parser.Parse(new ASTStringReader(input)).ToString(), input);
        }
    }
}