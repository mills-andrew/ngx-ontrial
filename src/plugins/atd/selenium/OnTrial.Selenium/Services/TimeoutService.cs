using OnTrial.Web;
using OpenQA.Selenium;
using System;

namespace OnTrial.Selenium
{
    /// <summary>
    /// <see cref="https://w3c.github.io/webdriver/#timeouts"/>
    /// </summary>
    public class TimeoutService : ITimeoutService
    {
        #region Public Properties

        public TimeSpan ImplicitWait
        {
            get { return this.getTimeout("implicit"); }
            set { this.setTimeout("implicit", value, TimeSpan.FromSeconds(0)); }
        }

        public TimeSpan PageLoad
        {
            get { return this.getTimeout("pageLoad"); }
            set { this.setTimeout("pageLoad", value, TimeSpan.FromSeconds(300)); }
        }

        public TimeSpan AsyncJavaScriptWait
        {
            get { return this.getTimeout("script"); }
            set { this.setTimeout("script", value, TimeSpan.FromSeconds(30)); }
        }

        #endregion

        protected IWebDriver mDriver;
        public TimeoutService(IWebDriver pDriver)
        {
            this.mDriver = pDriver;
        }

        #region Private Method(s)

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-timeouts"/>
        /// </summary>
        /// <param name="pTimeoutName"></param>
        /// <returns></returns>
        private TimeSpan getTimeout(string pTimeoutName)
        {
            if (pTimeoutName == "implicit")
                return mDriver.Manage().Timeouts().ImplicitWait;
            else if (pTimeoutName == "pageLoad")
                return mDriver.Manage().Timeouts().PageLoad;
            else if (pTimeoutName == "script")
                return mDriver.Manage().Timeouts().AsynchronousJavaScript;
            else
                throw new ArgumentException($"Could not determine the timeout requested ['{pTimeoutName}'");
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#set-timeouts"/>
        /// </summary>
        /// <param name="pTimeoutName"></param>
        /// <param name="pTimeout"></param>
        /// <param name="pDefault"></param>
        /// <returns></returns>
        private object setTimeout(string pTimeoutName, TimeSpan pTimeout, TimeSpan pDefault)
        {
            if (pTimeoutName == "implicit")
                return mDriver.Manage().Timeouts().ImplicitWait = pTimeout;
            else if (pTimeoutName == "pageLoad")
                return mDriver.Manage().Timeouts().PageLoad = pTimeout;
            else if (pTimeoutName == "script")
                return mDriver.Manage().Timeouts().AsynchronousJavaScript = pTimeout;
            else
                throw new ArgumentException($"Could not determine the timeout requested ['{pTimeoutName}'");
        }

        #endregion
    }
}
