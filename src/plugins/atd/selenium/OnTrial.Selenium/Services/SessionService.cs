using OnTrial.Web;
using OpenQA.Selenium;
using System;

namespace OnTrial.Selenium
{
    public class SessionService : ISessionService
    {
        public string Id { get; set; }

        protected IWebDriver mDriver;
        public SessionService(IWebDriver pDriver)
        {
            this.mDriver = pDriver;
        }

        #region Public Method(s)

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#new-session"/>
        /// </summary>
        /// <param name="pAgent"></param>
        public void NewSession()
        {
            throw new NotSupportedException("Selenium doesn't support direct session creation.");
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#delete-session"/>
        /// </summary>
        /// <param name="pAgent"></param>
        public void DeleteSession()
        {
            mDriver.Quit();
            this.Id = null;
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#status"/>
        /// </summary>
        /// <returns></returns>
        public bool Status()
        {
            throw new NotSupportedException("Selenium doesn't support direct status checking.");
        }

        #endregion
    }
}
