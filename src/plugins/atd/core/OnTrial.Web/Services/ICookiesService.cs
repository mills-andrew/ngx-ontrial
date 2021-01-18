using OnTrial.Api;

namespace OnTrial.Web
{
    public interface ICookiesService
    {
        #region Public Method(s)

        /// <summary>
        /// Delete the cookie by passing in the name of the cookie
        /// </summary>
        /// <param name="pName">The name of the cookie that is in the browser</param>
        public void DeleteCookieNamed(string pName);

        #endregion

        #region Base Method(s)

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-all-cookies"/>
        /// </summary>
        /// <returns></returns>
        public Cookie[] GetAllCookies();

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-named-cookie"/>
        /// </summary>
        /// <param name="pName"></param>
        /// <returns></returns>
        public Cookie GetNamedCookie(string pName);

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#add-cookie"/>
        /// </summary>
        /// <param name="pCookie"></param>
        public void AddCookie(Cookie pCookie);

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#delete-cookie"/>
        /// </summary>
        /// <param name="pCookie">An object that represents a copy of the cookie that needs to be deleted</param>
        public void DeleteCookie(Cookie pCookie);

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#delete-all-cookies"/>
        /// </summary>
        public void DeleteAllCookies();

        #endregion
    }
}