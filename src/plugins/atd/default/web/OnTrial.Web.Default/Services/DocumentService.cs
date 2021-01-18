using System.Collections.Generic;

namespace OnTrial.Web.Default
{
    /// <summary>
    /// <see cref="https://w3c.github.io/webdriver/#document"/>
    /// </summary>
    public class DocumentService : IDocumentService
    {
        protected WebAgent mAgent;

        public DocumentService(WebAgent pAgent)
        {
            this.mAgent = pAgent;
        }


        #region Public Method(s)

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-page-source"/>
        /// </summary>
        /// <returns></returns>
        public string PageSource()
        {
            return this.mAgent.ExecuteEndPoint(WebCommand.GetPageSource)["value"]?.ToString();
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#execute-script"/>
        /// </summary>
        /// <param name="pScript"></param>
        /// <param name="pArgs"></param>
        /// <returns></returns>
        public object ExecuteScript(string pScript, params object[] pArgs)
        {
            return this.mAgent.ExecuteEndPoint(WebCommand.ExecuteScript, new Dictionary<string, object>()
            {
                { "script", pScript },
                { "args", pArgs }
            });
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#execute-async-script"/>
        /// </summary>
        /// <param name="pScript"></param>
        /// <param name="pArgs"></param>
        /// <returns></returns>
        public object ExecuteAsyncScript(string pScript, params object[] pArgs)
        {
            return this.mAgent.ExecuteEndPoint(WebCommand.ExecuteAsyncScript, new Dictionary<string, object>()
            {
                { "script", pScript },
                { "args", pArgs }
            });
        }

        #endregion
    }
}
