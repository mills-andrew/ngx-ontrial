using TechTalk.SpecFlow;

namespace OnTrial.Specflow.Web
{
    [Binding]
    public class BrowserServiceSteps : WebSteps
    {
        [When(@"I click browser's back button")]
        public void WhenIClickBackBrowserButton()
        {
            mAgent.Navigation.Back();
        }

        [When(@"I click browser's forward button")]
        public void WhenIClickForwardBrowserButton()
        {
            mAgent.Navigation.Forward();
        }

        [When(@"I click browser's refresh button")]
        [When(@"I refresh the browser")]
        [When(@"I refresh the page")]
        public void WhenIClickRefreshBrowserButton()
        {
            mAgent.Navigation.Refresh();
        }

        [When(@"I maximize the browser")]
        public void WhenIMaximizeBrowser()
        {
            mAgent.Context.MaximizeWindow();
        }

        [When(@"I navigate to URL (.*)")]
        [When(@"I navigate to URL = (.*)")]
        public void WhenINavigateToUrl(string pUrl)
        {
            mAgent.Navigation.NavigateTo(new System.Uri(pUrl));
        }
    }
}
