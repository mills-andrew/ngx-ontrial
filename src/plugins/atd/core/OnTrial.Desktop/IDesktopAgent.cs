using System.Collections.Generic;

namespace OnTrial.Desktop
{
    public interface IDesktopAgent
    {
        public string Id { get; set; }

        public ISessionService Session { get; set; }
        public IDesktopService Service { get; set; }
        public IOptionsService Options { get; set; }
        public IWindowService Window { get; set; }

        public IDictionary<string, object> ExecuteEndPoint<T>(T pType, Dictionary<string, object> pCapabilities = null);

        #region Public Method(s)

        public IDesktopElement FindElement(DesktopLocator pKey, string pValue);
        public IDesktopElement FindElement(List<(DesktopLocator Key, string Value)> pSearchCriteria);
        public IDesktopElement FindElement(IDesktopElement pParentElement, DesktopLocator pKey, string pValue);
        public IDesktopElement FindElement(IDesktopElement pParentElement, List<(DesktopLocator Key, string Value)> pSearchCriteria);
        public IReadOnlyCollection<IDesktopElement> FindElements(DesktopLocator pKey, string pValue);
        public IReadOnlyCollection<IDesktopElement> FindElements(IDesktopElement pParentElement, DesktopLocator pKey, string pValue);

        #endregion
    }
}
