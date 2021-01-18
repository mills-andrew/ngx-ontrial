using OnTrial.Web;
using OpenQA.Selenium;
using System;

namespace OnTrial.Selenium
{
    public class NavigationService : INavigationService
    {
        protected IWebDriver mDriver;
        public NavigationService(IWebDriver pDriver)
        {
            this.mDriver = pDriver;
        }

        #region Public Method(s)

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#navigate-to"/>
        /// </summary>
        /// <param name="pUrl"></param>
        public void NavigateTo(Uri pUrl)
        {
            this.NavigateTo(pUrl.ToString());
        }

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#navigate-to"/>
        /// </summary>
        /// <param name="pUrl"></param>
        public void NavigateTo(string pUrl)
        {
            mDriver.Navigate().GoToUrl(pUrl);
        }

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#get-current-url"/>
        /// </summary>
        /// <returns>Url of current website</returns>
        public string GetCurrentUrl()
        {
            return mDriver.Url;
        }

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#back"/>
        /// </summary>
        public void Back()
        {
            mDriver.Navigate().Back();
        }

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#forward"/>
        /// </summary>
        public void Forward()
        {
            mDriver.Navigate().Forward();
        }

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#refresh"/>
        /// </summary>
        public void Refresh()
        {
            mDriver.Navigate().Refresh();
        }

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#"/>
        /// </summary>
        /// <returns>Title of website</returns>
        public string GetTitle()
        {
            return mDriver.Title;
        }

        #endregion
    }
}
