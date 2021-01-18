using System.Collections.Generic;

namespace OnTrial.Web
{
    public interface IFindWebElement
    {
        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-element"/>
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        IWebElement FindElement(WebLocator pKey, string pValue);

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-element"/>
        /// </summary>
        /// <param name="pSearchCriteria"></param>
        /// <returns></returns>
        IWebElement FindElement(List<(WebLocator Key, string Value)> pSearchCriteria);

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-element"/>
        /// </summary>
        /// <param name="pParentElement"></param>
        /// <param name="pKey"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        IWebElement FindElement(IWebElement pParentElement, WebLocator pKey, string pValue);

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-element"/>
        /// </summary>
        /// <param name="pParentElement"></param>
        /// <param name="pSearchCriteria"></param>
        /// <returns></returns>
        IWebElement FindElement(IWebElement pParentElement, List<(WebLocator Key, string Value)> pSearchCriteria);

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-elements"/>
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        IReadOnlyCollection<IWebElement> FindElements(WebLocator pKey, string pValue);

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-elements"/>
        /// </summary>
        /// <param name="pParentElement"></param>
        /// <param name="pKey"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        IReadOnlyCollection<IWebElement> FindElements(IWebElement pParentElement, WebLocator pKey, string pValue);

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        IWebTable FindWebTable(WebLocator pKey, string pValue);
    }
}
