using AST.Util;
using Language.Util;
using NUnit.Framework;

namespace Tests.Integration.Parsing
{
    [TestFixture]
    public class PatternTester
    {
        [Test]
        public void PatternTest()
        {
            Test("basic literal", new [] { "basicliteral", "basic literal" }, "not basic literal");
            Test("[optional] literal", new []{ "optional literal", "literal"}, "optional");
        }

        private static void Test(string pattern, string[] pass, params string[] fails)
        {
            Pattern testing = PatternFactory.Compile(pattern);
            foreach (string passing in pass)
            {
                Assert.AreNotEqual(-1, testing.Matches(passing.ToCharArray(), 0).Length);   
            }
            foreach (string failing in fails)
            {
                Assert.AreEqual(-1, testing.Matches(failing.ToCharArray(), 0).Length);   
            }
        }
    }
}