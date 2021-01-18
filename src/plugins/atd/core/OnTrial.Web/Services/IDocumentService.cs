namespace OnTrial.Web
{
    public interface IDocumentService
    {
        #region Public Method(s)

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#get-page-source"/>
        /// </summary>
        /// <returns></returns>
        string PageSource();

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#execute-script"/>
        /// </summary>
        /// <param name="pScript"></param>
        /// <param name="pArgs"></param>
        /// <returns></returns>
        object ExecuteScript(string pScript, params object[] pArgs);

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#execute-async-script"/>
        /// </summary>
        /// <param name="pScript"></param>
        /// <param name="pArgs"></param>
        /// <returns></returns>
        object ExecuteAsyncScript(string pScript, params object[] pArgs);

        #endregion
    }
}
