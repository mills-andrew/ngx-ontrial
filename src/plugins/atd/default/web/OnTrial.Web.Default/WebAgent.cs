using Newtonsoft.Json;
using OnTrial.Actions;
using OnTrial.Api;
using OnTrial.Logger;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnTrial.Web.Default
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

        public WebAgent(string pId, OptionsService pOptions, WebService pService)
        {
            this.Id = pId;
            this.Service = pService;
            this.Options = pOptions;
            

            Service.Client = new ApiClient(Service.ToUri);
            Capabilities = pOptions.ToCapabilities();
        }

        public void Build()
        {
            this.Context = new ContextService(this);
            this.Navigation = new NavigationService(this);
            this.Timeout = new TimeoutService(this);
            this.Cookies = new CookiesService(this);
            this.Session = new SessionService(this);
            this.Document = new DocumentService(this);
            this.Actions = new ActionsService();

            this.Actions.ExecutionCall = () => this.ExecuteEndPoint(WebCommand.PerformActions, this.Actions.ToDictionary());
        }

        public IDictionary<string, object> ExecuteEndPoint<T>(T pType, Dictionary<string, object> pCapabilities = null)
        {
            IDictionary<string, object> webResponse = new Dictionary<string, object>();
            Service.Protocol.EndPoints.TryGetValue(pType, out EndPoint ePoint);
            if (pCapabilities == null)
                pCapabilities = new Dictionary<string, object>();
            pCapabilities?.Add("session id", this.Session.Id);

            Command cmd = new Command(ePoint, pCapabilities);
            string path = cmd.ToString();
            cmd.Parameters.Remove("session id");
            string body = cmd.ToJson();

            string rawResponse = Service.Client.SendRequestAsync(cmd.EndPoint.Method, path, body).Content.ReadAsStringAsync().Result;
            Dictionary<string, object> result = JsonConvert.DeserializeObject<Dictionary<string, object>>(rawResponse, new LayerdJsonConverter());

            if (result == null)
                return null;

            webResponse = new Dictionary<string, object>();

            if (result.ContainsKey("value"))
            {
                Dictionary<string, object> value = result["value"] as Dictionary<string, object>;
                value = value ?? new Dictionary<string, object> { { result.ElementAt(0).Key, result.ElementAt(0).Value } };

                if (value == null)
                    return null;

                if (value.ContainsKey("value"))
                    webResponse.Add("value", value["value"]);
                else
                    webResponse.Add("value", value);

                if (value.ContainsKey("capabilities"))
                    webResponse.Add("capabilities", value["capabilities"]);

                if (value.ContainsKey("sessionId"))
                    webResponse.Add("sessionId", value["sessionId"]);

                if (value.ContainsKey("error"))
                {
                    webResponse.Add("error", value["error"]);
                    if (value.ContainsKey("message"))
                        webResponse.Add("message", value["message"]);

                    if (value.ContainsKey("stacktrace"))
                        webResponse.Add("stacktrace", value["stacktrace"]);

                    if (Service.Protocol.Exceptions.ContainsKey(value["error"]))
                    {
                        Log.Error(value["message"].ToString());
                        throw (Exception)Activator.CreateInstance(Service.Protocol.Exceptions[value["error"].ToString()], value["message"].ToString());
                    }
                }
            }

            return webResponse;
        }

        #region Find Element(s)

        #region Find Custom Object(s)


        #endregion

        #region Public Method(s)

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-element"/>
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public IWebElement FindElement(WebLocator pKey, string pValue)
        {
            return this.FindElement(Service.Protocol.Locators[pKey], pValue);
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-element"/>
        /// </summary>
        /// <param name="pSearchCriteria"></param>
        /// <returns></returns>
        public IWebElement FindElement(List<(WebLocator Key, string Value)> pSearchCriteria)
        {
            return this.FindElement(pSearchCriteria.Select(m => (Service.Protocol.Locators[m.Key], m.Value)).ToList());
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-element"/>
        /// </summary>
        /// <param name="pParentElement"></param>
        /// <param name="pKey"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public IWebElement FindElement(IWebElement pParentElement, WebLocator pKey, string pValue)
        {
            return this.FindElement(pParentElement.Id, Service.Protocol.Locators[pKey], pValue);
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-element"/>
        /// </summary>
        /// <param name="pParentElement"></param>
        /// <param name="pSearchCriteria"></param>
        /// <returns></returns>
        public IWebElement FindElement(IWebElement pParentElement, List<(WebLocator Key, string Value)> pSearchCriteria)
        {
            return this.FindElement(pParentElement.Id, pSearchCriteria.Select(m => (Service.Protocol.Locators[m.Key], m.Value)).ToList());
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-elements"/>
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public IReadOnlyCollection<IWebElement> FindElements(WebLocator pKey, string pValue)
        {
            return this.FindElements(Service.Protocol.Locators[pKey], pValue);
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-elements"/>
        /// </summary>
        /// <param name="pParentElement"></param>
        /// <param name="pKey"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        public IReadOnlyCollection<IWebElement> FindElements(IWebElement pParentElement, WebLocator pKey, string pValue)
        {
            return this.FindElements(pParentElement.Id, Service.Protocol.Locators[pKey], pValue);
        }

        #endregion

        #region Private Method(s)

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-element"/>
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        private IWebElement FindElement(string pKey, string pValue)
        {
            Log.Information($"Finding Element ({pKey}, {pValue})");
            IDictionary<string, object> response = this.ExecuteEndPoint(WebCommand.FindElement, new Dictionary<string, object>()
            {
                { "using", pKey },
                { "value", pValue }
            });

            Dictionary<string, object> elementDictionary = response["value"] as Dictionary<string, object>;

            if (elementDictionary == null)
                throw new ArgumentNullException("");

            string elementId = elementDictionary[IWebElement.KeyId].ToString();

            if (string.IsNullOrEmpty(elementId))
                throw new ArgumentNullException("The specified element Id is either null or the empty string");

            return new WebElement(this, elementId);
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-element"/>
        /// </summary>
        /// <param name="pSearchCriteria"></param>
        /// <returns></returns>
        private IWebElement FindElement(List<(string Key, string Value)> pSearchCriteria)
        {
            Log.Information($"Finding most common element.");

            if (pSearchCriteria == null)
                throw new ArgumentNullException();

            List<IWebElement> finalElementsFound = new List<IWebElement>();

            // Create a list to hold our element ids
            List<string> finalElementIds = new List<string>();
            foreach (var locator in pSearchCriteria)
            {
                IReadOnlyCollection<IWebElement> foundElements = this.FindElements(locator.Key, locator.Value);
                finalElementIds.AddRange(foundElements.Select(m => m.Id).ToList());
            }

            return new WebElement(this, finalElementIds.MostCommon());
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-element"/>
        /// </summary>
        /// <param name="pParentId"></param>
        /// <param name="pKey"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        private IWebElement FindElement(string pParentId, string pKey, string pValue)
        {
            Log.Information($"Finding Child Element ({pKey}, {pValue})");

            IDictionary<string, object> response = this.ExecuteEndPoint(WebCommand.FindElementFromElement, new Dictionary<string, object>()
            {
                { "id", pParentId },
                { "using", pKey },
                { "value", pValue }
            });

            Dictionary<string, object> elementDictionary = null;

            if (elementDictionary == null)
                throw new ArgumentNullException("");

            string elementId = elementDictionary[IWebElement.KeyId].ToString();

            if (string.IsNullOrEmpty(elementId))
                throw new ArgumentNullException("The specified element Id is either null or the empty string");

            return (WebElement)new WebElement(this, elementId);
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-element"/>
        /// </summary>
        /// <param name="pParentId"></param>
        /// <param name="pSearchCriteria"></param>
        /// <returns></returns>
        private IWebElement FindElement(string pParentId, List<(string Key, string Value)> pSearchCriteria)
        {
            Log.Information($"Finding most common child element.");

            if (pSearchCriteria == null)
                throw new ArgumentNullException();

            List<IWebElement> finalElementsFound = new List<IWebElement>();

            // Create a list to hold our element ids
            List<string> finalElementIds = new List<string>();
            foreach (var locator in pSearchCriteria)
            {
                IReadOnlyCollection<IWebElement> foundElements = this.FindElements(pParentId, locator.Key, locator.Value);
                finalElementIds.AddRange(foundElements.Select(m => m.Id).ToList());
            }

            return new WebElement(this, finalElementIds.MostCommon());
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-elements"/>
        /// </summary>
        /// <param name="pKey"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        private IReadOnlyCollection<IWebElement> FindElements(string pKey, string pValue)
        {
            Log.Information($"Finding Element ({pKey}, {pValue})");
            List<WebElement> finalElementsFound = new List<WebElement>();
            IDictionary<string, object> response = this.ExecuteEndPoint(WebCommand.FindElements, new Dictionary<string, object>()
            {
                { "using", pKey },
                { "value", pValue }
            });

            Dictionary<string, object> elementDictionary = response as Dictionary<string, object>;
            object[] elementArray = elementDictionary["value"] as object[];

            if (elementArray == null)
                return finalElementsFound.AsReadOnly();

            foreach (object elementObject in elementArray)
            {
                Dictionary<string, object> element = elementObject as Dictionary<string, object>;

                if (element != null)
                {
                    string elementId = element[IWebElement.KeyId].ToString();

                    if (string.IsNullOrEmpty(elementId))
                        throw new ArgumentNullException("The specified element Id is either null or the empty string");

                    finalElementsFound.Add(new WebElement(this, elementId));
                }
            }

            return finalElementsFound;
        }

        /// <summary>
        /// <see cref="https://w3c.github.io/webdriver/#find-elements"/>
        /// </summary>
        /// <param name="pParentId"></param>
        /// <param name="pKey"></param>
        /// <param name="pValue"></param>
        /// <returns></returns>
        private IReadOnlyCollection<IWebElement> FindElements(string pParentId, string pKey, string pValue)
        {
            Log.Information($"Finding Child Element ({pKey}, {pValue})");

            List<WebElement> finalElementsFound = new List<WebElement>();
            IDictionary<string, object> response = this.ExecuteEndPoint(WebCommand.FindElementsFromElement, new Dictionary<string, object>()
            {
                { "id", pParentId },
                { "using", pKey },
                { "value", pValue }
            });

            object[] elements = response["value"] as object[];

            if (elements == null)
                return finalElementsFound.AsReadOnly();

            foreach (object elementObject in elements)
            {
                Dictionary<string, object> elementDictionary = elementObject as Dictionary<string, object>;
                if (elementDictionary != null)
                {
                    string elementId = elementDictionary[IWebElement.KeyId].ToString();

                    if (string.IsNullOrEmpty(elementId))
                        throw new ArgumentNullException("The specified element Id is either null or the empty string");

                    finalElementsFound.Add(new WebElement(this, elementId));
                }
            }

            return finalElementsFound;
        }

        public IWebTable FindWebTable(WebLocator pKey, string pValue)
        {
            return new WebTable(this, pKey, pValue);
        }

        #endregion

        #endregion
    }
}
