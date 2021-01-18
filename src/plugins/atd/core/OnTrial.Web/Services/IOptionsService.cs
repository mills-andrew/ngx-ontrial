using System.Collections.Generic;

namespace OnTrial.Web
{
    public interface IOptionsService
    {
        public string PlatformName { get; set; }
        public string BrowserName { get; set; }
        public string CapabilityKey { get; set; }

        void BuildBaseOptions(out Dictionary<string, object> pOptions);
        Dictionary<string, object> ToCapabilities();
    }
}