using OnTrial.MSTest;
using OnTrial.MSTest.Web;

namespace OnTrial.Web.Tests
{
    [TestSuite]
    public class FindElementTests : DefaultWebTestBase
    {
        #region Test Cases

        #region CssSelector

        [TestCase]
        public void AbilityTo_FindElement_ByCss() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void AbilityTo_FindElements_ByCss() => Assert.Inconclusive("Testcase not complete."); 

        [TestCase]
        public void Validate_NoElementException_ByCss() => Assert.Inconclusive("Testcase not complete."); 

        #endregion

        #region LinkText

        [TestCase]
        public void AbilityTo_FindElement_ByLinkText() => Assert.Inconclusive("Testcase not complete.");

        [TestCase]
        public void AbilityTo_FindElements_ByLinkText() => Assert.Inconclusive("Testcase not complete.");

        [TestCase]
        public void Validate_NoElementException_ByLinkText() => Assert.Inconclusive("Testcase not complete.");

        #endregion

        #region PartialLinkText

        [TestCase]
        public void AbilityTo_FindElement_ByPartialLinkText() => Assert.Inconclusive("Testcase not complete.");

        [TestCase]
        public void AbilityTo_FindElements_ByPartialLinkText() => Assert.Inconclusive("Testcase not complete.");

        [TestCase]
        public void Validate_NoElementException_ByPartialLinkText() => Assert.Inconclusive("Testcase not complete.");

        #endregion

        #region TagName

        [TestCase]
        public void AbilityTo_FindElement_ByTagName() => Assert.Inconclusive("Testcase not complete.");

        [TestCase]
        public void AbilityTo_FindElements_ByTagName() => Assert.Inconclusive("Testcase not complete.");

        [TestCase]
        public void Validate_NoElementException_ByTagName() => Assert.Inconclusive("Testcase not complete.");

        #endregion

        #region XPath

        [TestCase]
        public void AbilityTo_FindElement_ByXPath() => Assert.Inconclusive("Testcase not complete.");

        [TestCase]
        public void AbilityTo_FindElements_ByXPath() => Assert.Inconclusive("Testcase not complete.");

        [TestCase]
        public void Validate_NoElementException_ByXPath() => Assert.Inconclusive("Testcase not complete.");

        #endregion

        #endregion
    }
}
