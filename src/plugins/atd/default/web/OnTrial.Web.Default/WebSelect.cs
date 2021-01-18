using System.Collections.Generic;
using System.Linq;

namespace OnTrial.Web.Default
{
    public class WebSelect : IWebSelect
    {
        #region Public Properties

        public List<IWebElement> Options => this.agent.FindElements(Element, WebLocator.Css, "option").ToList();
        public IWebElement Element => this.agent.FindElement(key, value);

        #endregion

        #region Private Properties

        private WebAgent agent;
        private WebLocator key;
        private string value;

        #endregion

        #region Constructor(s)

        public WebSelect(WebAgent pAgent, WebLocator pKey, string pValue)
        {
            this.agent = pAgent;
            this.key = pKey;
            this.value = pValue;
        }

        #endregion

        public void Select(string pValue)
        {
            var opts = Options;
            var list = Options.Select(m => m.Text).ToList();

            opts.First(m => m.Text == pValue).Click();
        }
    }
}
