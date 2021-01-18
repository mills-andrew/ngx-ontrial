using OnTrial.Web;
using OpenQA.Selenium;

namespace OnTrial.Selenium
{
    /// <summary>
    /// <see cref="https://w3c.github.io/webdriver/#document"/>
    /// </summary>
    public class DocumentService : IDocumentService
    {
        protected IWebDriver mDriver;
        public DocumentService(IWebDriver pDriver)
        {
            this.mDriver = pDriver;
        }

        #region Public Method(s)

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-page-source"/>
        /// </summary>
        /// <returns></returns>
        public string PageSource()
        {
            return this.mDriver.PageSource;
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#execute-script"/>
        /// </summary>
        /// <param name="pScript"></param>
        /// <param name="pArgs"></param>
        /// <returns></returns>
        public object ExecuteScript(string pScript, params object[] pArgs)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)mDriver;
            return js.ExecuteScript(pScript, pArgs);
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#execute-async-script"/>
        /// </summary>
        /// <param name="pScript"></param>
        /// <param name="pArgs"></param>
        /// <returns></returns>
        public object ExecuteAsyncScript(string pScript, params object[] pArgs)
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)mDriver;
            return js.ExecuteAsyncScript(pScript, pArgs);
        }

        #endregion
    }
}
