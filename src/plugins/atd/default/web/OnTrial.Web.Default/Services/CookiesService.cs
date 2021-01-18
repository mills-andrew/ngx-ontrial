using System;
using System.Collections.Generic;

namespace OnTrial.Web.Default
{
    /// <summary>
    /// <see cref="https://w3c.github.io/webdriver/#cookies"/>
    /// </summary>
    public class CookiesService : ICookiesService
    {
        protected WebAgent mAgent;
        public CookiesService(WebAgent pAgent)
        {
            this.mAgent = pAgent;
        }

        #region Public Method(s)

        /// <summary>
        /// Delete the cookie by passing in the name of the cookie
        /// </summary>
        /// <param name="pName">The name of the cookie that is in the browser</param>
        public void DeleteCookieNamed(string pName)
        {
            this.mAgent.ExecuteEndPoint(WebCommand.DeleteCookie, new Dictionary<string, object>()
            {
                { "name", pName }
            });
        }

        #endregion

        #region Base Method(s)

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-all-cookies"/>
        /// </summary>
        /// <returns></returns>
        public Api.Cookie[] GetAllCookies()
        {
            this.mAgent.ExecuteEndPoint(WebCommand.GetAllCookies);
            throw new NotImplementedException();
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-named-cookie"/>
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public Api.Cookie GetNamedCookie(string pName)
        {
            this.mAgent.ExecuteEndPoint(WebCommand.GetNamedCookie);
            throw new NotImplementedException();
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#add-cookie"/>
        /// </summary>
        /// <param name="pCookie"></param>
        public void AddCookie(Api.Cookie pCookie)
        {
            this.mAgent.ExecuteEndPoint(WebCommand.AddCookie, new Dictionary<string, object>()
            {
                { "cookie", pCookie }
            });
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
            this.mAgent.ExecuteEndPoint(WebCommand.DeleteAllCookies);
        }

        #endregion
    }
}
