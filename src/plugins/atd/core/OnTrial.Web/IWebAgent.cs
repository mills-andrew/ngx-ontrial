using OnTrial.Actions;
using System.Collections.Generic;

namespace OnTrial.Web
{
    public interface IWebAgent : IFindWebElement
    {
        public string Id { get; set; }
        public IDictionary<string, object> Capabilities { get; set; }

        #region Services

        INavigationService Navigation { get; set; }
        IDocumentService Document { get; set; }
        ITimeoutService Timeout { get; set; }
        IWebService Service { get; set; }
        IOptionsService Options { get; set; }
        ICookiesService Cookies { get; set; }
        IContextService Context { get; set; }
        ISessionService Session { get; set; }
        ActionsService Actions { get; set; }

        #endregion
    }
}
