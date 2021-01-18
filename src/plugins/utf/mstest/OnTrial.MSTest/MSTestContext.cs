using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;

namespace OnTrial.MSTest
{
    public class MSTestContext
    {
        private TestContext _testContext;

        public string ClassName => _testContext.FullyQualifiedTestClassName;
        public string MethodName => _testContext.TestName;
        public string FullTestName => $"{ClassName}.{MethodName}";

        public IDictionary Properties => _testContext.Properties;

        public MSTestContext(TestContext testContext)
        {
            _testContext = testContext;
        }
    }
}
