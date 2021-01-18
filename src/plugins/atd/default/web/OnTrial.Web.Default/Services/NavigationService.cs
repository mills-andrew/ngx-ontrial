using OnTrial.Web.Default;
using System;
using System.Collections.Generic;

namespace OnTrial.Web
{
    public class NavigationService : INavigationService
    {
        protected WebAgent mAgent;
        public NavigationService(WebAgent pAgent)
        {
            this.mAgent = pAgent;
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
            if (string.IsNullOrEmpty(pUrl))
                throw new ArgumentNullException(nameof(pUrl));
            mAgent.ExecuteEndPoint(WebCommand.NavigateTo, new Dictionary<string, object>()
            {
                { "url", pUrl }
            });
        }

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#get-current-url"/>
        /// </summary>
        /// <returns>Url of current website</returns>
        public string GetCurrentUrl()
        {
            return mAgent.ExecuteEndPoint(WebCommand.GetCurrentUrl).ToString();
        }

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#back"/>
        /// </summary>
        public void Back()
        {
            mAgent.ExecuteEndPoint(WebCommand.Back);
        }

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#forward"/>
        /// </summary>
        public void Forward()
        {
            mAgent.ExecuteEndPoint(WebCommand.Forward);
        }

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#refresh"/>
        /// </summary>
        public void Refresh()
        {
            mAgent.ExecuteEndPoint(WebCommand.Refresh);
        }

        /// <summary>
        /// <see cref="https://www.w3.org/TR/webdriver/#"/>
        /// </summary>
        /// <returns>Title of website</returns>
        public string GetTitle()
        {
            return mAgent.ExecuteEndPoint(WebCommand.GetTitle)["value"].ToString();
        }

        #endregion
    }
}
