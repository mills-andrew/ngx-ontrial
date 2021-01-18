using OnTrial.Web;
using OpenQA.Selenium;
using System.Collections.ObjectModel;
using System.Linq;

namespace OnTrial.Selenium
{
    /// <summary>
    /// <see cref="https://w3c.github.io/webdriver/#cookies"/>
    /// </summary>
    public class CookiesService : ICookiesService
    {
        protected IWebDriver mDriver;
        public CookiesService(IWebDriver pDriver)
        {
            this.mDriver = pDriver;
        }

        #region Public Method(s)

        /// <summary>
        /// Delete the cookie by passing in the name of the cookie
        /// </summary>
        /// <param name="pName">The name of the cookie that is in the browser</param>
        public void DeleteCookieNamed(string pName)
        {
            mDriver.Manage().Cookies.DeleteCookieNamed(pName);
        }

        #endregion

        #region Base Method(s)

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-all-cookies"/>
        /// </summary>
        /// <returns></returns>
        public Api.Cookie[] GetAllCookies()
        {
            ReadOnlyCollection<Cookie> seleniumCookies = mDriver.Manage().Cookies.AllCookies;
            return seleniumCookies.Select(m => new Api.Cookie(m.Name, m.Value)).ToArray();
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-named-cookie"/>
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public Api.Cookie GetNamedCookie(string pName)
        {
            Cookie c = mDriver.Manage().Cookies.GetCookieNamed(pName);
            return new Api.Cookie(c.Name, c.Value);
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#add-cookie"/>
        /// </summary>
        /// <param name="pCookie"></param>
        public void AddCookie(Api.Cookie pCookie)
        {
            mDriver.Manage().Cookies.AddCookie(new Cookie(pCookie.Name, pCookie.Value));
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#delete-cookie"/>
        /// </summary>
        /// <param name="pCookie">An object that represents a copy of the cookie that needs to be deleted</param>
        public void DeleteCookie(Api.Cookie pCookie)
        {
            if (pCookie != null)
                this.DeleteCookieNamed(pCookie.Name);
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#delete-all-cookies"/>
        /// </summary>
        public void DeleteAllCookies()
        {
            mDriver.Manage().Cookies.DeleteAllCookies();
        }

        #endregion
    }
}
