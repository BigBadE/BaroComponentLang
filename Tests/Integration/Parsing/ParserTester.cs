using AST.Parser;
using NUnit.Framework;

namespace Tests.Integration.Parsing
{
    [TestFixture]
    public class ParserTester
    {
        private readonly ASTParser _parser = new();
        
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