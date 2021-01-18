using OnTrial.MSTest;
using OnTrial.MSTest.Web;
using System;

namespace OnTrial.Web.Tests
{
    [TestSuite]
    [Browser(BrowserType.Edge)]
    public class UserPromptTest : DefaultWebTestBase
    {
        [TestCase]
        public void TEST()
        {
            try
            {
                mAgent.Navigation.NavigateTo("https://www.google.ca/");
            }
            catch (Exception e)
            {
                Assert.Inconclusive("Inconclusive Test: " + e.Message.ToString());
            }

            try
            {
            }
            catch (Exception e)
            {
                Assert.Fail("Failed Test: " + e.Message.ToString());
            }
        }

        [TestCase]
        public void ShouldBeAbleToOverrideTheWindowAlertMethod()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldAllowUsersToAcceptAnAlertManually()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldThrowArgumentNullExceptionWhenKeysNull()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldAllowUsersToAcceptAnAlertWithNoTextManually()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldGetTextOfAlertOpenedInSetTimeout()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldAllowUsersToDismissAnAlertManually()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldAllowAUserToAcceptAPrompt()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldAllowAUserToDismissAPrompt()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldAllowAUserToSetTheValueOfAPrompt()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void SettingTheValueOfAnAlertThrows()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldAllowTheUserToGetTheTextOfAnAlert()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldAllowTheUserToGetTheTextOfAPrompt()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void AlertShouldNotAllowAdditionalCommandsIfDimissed()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldAllowUsersToAcceptAnAlertInAFrame()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldAllowUsersToAcceptAnAlertInANestedFrame()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void SwitchingToMissingAlertThrows()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void SwitchingToMissingAlertInAClosedWindowThrows()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void PromptShouldUseDefaultValueIfNoKeysSent()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void PromptShouldHaveNullValueIfDismissed()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void HandlesTwoAlertsFromOneInteraction()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldHandleAlertOnPageLoad()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldHandleAlertOnPageLoadUsingGet()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldNotHandleAlertInAnotherWindow()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldHandleAlertOnPageUnload()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldImplicitlyHandleAlertOnPageBeforeUnload()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldHandleAlertOnWindowClose()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void IncludesAlertTextInUnhandledAlertException()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void CanQuitWhenAnAlertIsPresent()
        {
            Assert.Inconclusive("Testcase not complete.");
        }

        [TestCase]
        public void ShouldHandleAlertOnFormSubmit()
        {
            Assert.Inconclusive("Testcase not complete.");
        }
    }
}