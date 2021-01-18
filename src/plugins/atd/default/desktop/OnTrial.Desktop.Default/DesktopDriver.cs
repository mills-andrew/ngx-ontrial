using Newtonsoft.Json;
using OnTrial.Api;
using OnTrial.Logger;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OnTrial.Desktop.Default
{
    public class DesktopDriver : IDesktopAgent
    {
        public string Id { get; set; }
        public ISessionService Session { get; set; }
        public IDesktopService Service { get; set; }
        public IOptionsService Options { get; set; }
        public IWindowService Window { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pOptions"></param>
        /// <param name="pService"></param>
        public DesktopDriver(string pId, IOptionsService pOptions, IDesktopService pService)
        {
            this.Id = pId;
            this.Service = pService;
            this.Options = pOptions;

            Service.BuildArguments();
            Service.Client = new ApiClient(Service.ToUri);
        }

        public void Build()
        {
            this.Window = new WindowService(this);
            this.Session = new SessionService(this);
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

            if (result.ContainsKey("sessionId"))
                webResponse.Add("sessionId", result["sessionId"]);

            if (result.ContainsKey("value"))
                webResponse.Add("value", result["value"]);

            if (result.ContainsKey("error"))
            {
                webResponse.Add("error", result["error"]);
                if (result.ContainsKey("message"))
                    webResponse.Add("message", result["message"]);

                if (result.ContainsKey("stacktrace"))
                    webResponse.Add("stacktrace", result["stacktrace"]);

                Log.Error(result["message"].ToString());
                throw (Exception)Activator.CreateInstance(Service.Protocol.Exceptions[result["error"].ToString()], result["message"].ToString());
            }

            return webResponse;
        }


        #region Public Method(s)

        public IDesktopElement FindElement(DesktopLocator pKey, string pValue)
        {
            return this.FindElement(Service.Protocol.Locators[pKey], pValue);
        }

        public IDesktopElement FindElement(List<(DesktopLocator Key, string Value)> pSearchCriteria)
        {
            return this.FindElement(pSearchCriteria.Select(m => (Service.Protocol.Locators[m.Key], m.Value)).ToList());
        }

        public IDesktopElement FindElement(IDesktopElement pParentElement, DesktopLocator pKey, string pValue)
        {
            return this.FindElement(pParentElement.Id, Service.Protocol.Locators[pKey], pValue);
        }

        public IDesktopElement FindElement(IDesktopElement pParentElement, List<(DesktopLocator Key, string Value)> pSearchCriteria)
        {
            return this.FindElement(pParentElement.Id, pSearchCriteria.Select(m => (Service.Protocol.Locators[m.Key], m.Value)).ToList());
        }

        public IReadOnlyCollection<IDesktopElement> FindElements(DesktopLocator pKey, string pValue)
        {
            return this.FindElements(Service.Protocol.Locators[pKey], pValue);
        }

        public IReadOnlyCollection<IDesktopElement> FindElements(IDesktopElement pParentElement, DesktopLocator pKey, string pValue)
        {
            return this.FindElements(pParentElement.Id, Service.Protocol.Locators[pKey], pValue);
        }

        #endregion

        #region Private Method(s)

        private IDesktopElement FindElement(string pKey, string pValue)
        {
            Log.Information($"Finding Element ({pKey}, {pValue})");
            IDictionary<string, object> response = this.ExecuteEndPoint(DesktopCommand.FindElement, new Dictionary<string, object>()
            {
                { "using", pKey },
                { "value", pValue }
            });

            Dictionary<string, object> elementDictionary = response["value"] as Dictionary<string, object>;

            if (elementDictionary == null)
                throw new ArgumentNullException("");

            string elementId = elementDictionary[IDesktopElement.KeyId].ToString();

            if (string.IsNullOrEmpty(elementId))
                throw new ArgumentNullException("The specified element Id is either null or the empty string");

            return new DesktopElement(this, elementId);
        }

        private IDesktopElement FindElement(List<(string Key, string Value)> pSearchCriteria)
        {
            Log.Information($"Finding most common element.");

            if (pSearchCriteria == null)
                throw new ArgumentNullException();

            List<IDesktopElement> finalElementsFound = new List<IDesktopElement>();

            // Create a list to hold our element ids
            List<string> finalElementIds = new List<string>();
            foreach (var locator in pSearchCriteria)
            {
                IReadOnlyCollection<IDesktopElement> foundElements = this.FindElements(locator.Key, locator.Value);
                finalElementIds.AddRange(foundElements.Select(m => m.Id).ToList());
            }

            return new DesktopElement(this, finalElementIds.MostCommon());
        }

        private IDesktopElement FindElement(string pParentId, string pKey, string pValue)
        {
            Log.Information($"Finding Child Element ({pKey}, {pValue})");

            IDictionary<string, object> response = this.ExecuteEndPoint(DesktopCommand.FindElementFromElement, new Dictionary<string, object>()
            {
                { "id", pParentId },
                { "using", pKey },
                { "value", pValue }
            });

            Dictionary<string, object> elementDictionary = null;

            if (elementDictionary == null)
                throw new ArgumentNullException("");

            string elementId = elementDictionary[IDesktopElement.KeyId].ToString();

            if (string.IsNullOrEmpty(elementId))
                throw new ArgumentNullException("The specified element Id is either null or the empty string");

            return new DesktopElement(this, elementId);
        }

        private IDesktopElement FindElement(string pParentId, List<(string Key, string Value)> pSearchCriteria)
        {
            Log.Information($"Finding most common child element.");

            if (pSearchCriteria == null)
                throw new ArgumentNullException();

            List<IDesktopElement> finalElementsFound = new List<IDesktopElement>();

            // Create a list to hold our element ids
            List<string> finalElementIds = new List<string>();
            foreach (var locator in pSearchCriteria)
            {
                IReadOnlyCollection<IDesktopElement> foundElements = this.FindElements(pParentId, locator.Key, locator.Value);
                finalElementIds.AddRange(foundElements.Select(m => m.Id).ToList());
            }

            return new DesktopElement(this, finalElementIds.MostCommon());
        }

        private IReadOnlyCollection<IDesktopElement> FindElements(string pKey, string pValue)
        {
            Log.Information($"Finding Element ({pKey}, {pValue})");
            List<IDesktopElement> finalElementsFound = new List<IDesktopElement>();
            IDictionary<string, object> response = this.ExecuteEndPoint(DesktopCommand.FindElements, new Dictionary<string, object>()
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
                    string elementId = element[IDesktopElement.KeyId].ToString();

                    if (string.IsNullOrEmpty(elementId))
                        throw new ArgumentNullException("The specified element Id is either null or the empty string");

                    finalElementsFound.Add(new DesktopElement(this, elementId));
                }
            }

            return finalElementsFound;
        }

        private IReadOnlyCollection<IDesktopElement> FindElements(string pParentId, string pKey, string pValue)
        {
            Log.Information($"Finding Child Element ({pKey}, {pValue})");

            List<IDesktopElement> finalElementsFound = new List<IDesktopElement>();
            IDictionary<string, object> response = this.ExecuteEndPoint(DesktopCommand.FindElementsFromElement, new Dictionary<string, object>()
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
                    string elementId = elementDictionary[IDesktopElement.KeyId].ToString();

                    if (string.IsNullOrEmpty(elementId))
                        throw new ArgumentNullException("The specified element Id is either null or the empty string");

                    finalElementsFound.Add(new DesktopElement(this, elementId));
                }
            }

            return finalElementsFound;
        }

        #endregion
    }
}
