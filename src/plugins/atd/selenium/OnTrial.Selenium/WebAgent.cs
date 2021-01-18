using OnTrial.Actions;
using OnTrial.Web;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnTrial.Selenium
{
    public class WebAgent : IWebAgent
    {
        public string Id { get; set; }

        public IDictionary<string, object> Capabilities { get; set; }
        public INavigationService Navigation { get; set; }
        public IDocumentService Document { get; set; }
        public ITimeoutService Timeout { get; set; }
        public IWebService Service { get; set; }
        public IOptionsService Options { get; set; }
        public ICookiesService Cookies { get; set; }
        public IContextService Context { get; set; }
        public ISessionService Session { get; set; }
        public ActionsService Actions { get; set; }

        protected IWebDriver mDriver;

        public WebAgent(string pId, IOptionsService pOptions, IWebService pService)
        {
            this.Id = pId;
            this.Options = pOptions;
            this.Service = pService;
        }

        protected void Build()
        {
            this.Context = new ContextService(mDriver);
            this.Navigation = new NavigationService(mDriver);
            this.Timeout = new TimeoutService(mDriver);
            this.Cookies = new CookiesService(mDriver);
            this.Session = new SessionService(mDriver);
            this.Document = new DocumentService(mDriver);
            this.Actions = new ActionsService();
        }

        private By ToByLocator(WebLocator pKey, string pValue)
        {
            switch(pKey)
            {
                case WebLocator.ClassName:
                    return By.ClassName(pValue);

                case WebLocator.Css:
                    return By.CssSelector(pValue);

                case WebLocator.LinkText:
                    return By.LinkText(pValue);

                case WebLocator.TagName:
                    return By.TagName(pValue);

                case WebLocator.XPath:
                    return By.XPath(pValue);

                default:
                    throw new ArgumentException("Unable to identify how to convert WebLocator Enum to By Class");
            }
        }

        public Web.IWebElement FindElement(WebLocator pKey, string pValue)
        {
            return new WebElement(mDriver, mDriver.FindElement(ToByLocator(pKey, pValue)));
        }

        public Web.IWebElement FindElement(List<(WebLocator Key, string Value)> pSearchCriteria)
        {
            throw new NotSupportedException("Selenium doesn't offer a naitive find element most common in selector query");
        }

        public Web.IWebElement FindElement(Web.IWebElement pParentElement, WebLocator pKey, string pValue)
        {
            throw new NotSupportedException("Selenium doesn't offer a naitive find element by parent");
        }

        public Web.IWebElement FindElement(Web.IWebElement pParentElement, List<(WebLocator Key, string Value)> pSearchCriteria)
        {
            throw new NotSupportedException("Selenium doesn't offer a naitive find element by parent");
        }

        public IReadOnlyCollection<Web.IWebElement> FindElements(WebLocator pKey, string pValue)
        {
            return mDriver.FindElements(ToByLocator(pKey, pValue)).Select(m => new WebElement(mDriver, m)).ToList();
        }

        public IReadOnlyCollection<Web.IWebElement> FindElements(Web.IWebElement pParentElement, WebLocator pKey, string pValue)
        {
            throw new NotSupportedException("Selenium doesn't offer a naitive find element by parent");
        }

        public IWebTable FindWebTable(WebLocator pKey, string pValue)
        {
            throw new NotSupportedException("Selenium doesn't offer a naitive find element by parent");
        }
    }
}
