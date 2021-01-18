using System.Collections.Generic;

namespace OnTrial.Web.Default
{
    public abstract class OptionsService : IOptionsService
    {
        #region Public Variables

        public string PlatformName { get; set; }
        public string BrowserName { get; set; }
        public string CapabilityKey { get; set; }

        #endregion

        #region Contractor(s)

        public OptionsService(string pPlatformName, string pBrowserName, string pCapabilityKey)
        {
            this.PlatformName = pPlatformName;
            this.BrowserName = pBrowserName;
            this.CapabilityKey = pCapabilityKey;
        }

        #endregion

        #region Public Method(s)

        public void BuildBaseOptions(out Dictionary<string, object> pOptions)
        {
            pOptions = new Dictionary<string, object>();
            pOptions.Add("platformName", this.PlatformName);
            pOptions.Add("browserName", this.BrowserName);
        }

        public abstract Dictionary<string, object> ToCapabilities();

        #endregion
    }
}