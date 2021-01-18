using System.Collections.Generic;

namespace OnTrial.Desktop.Default
{
    public abstract class OptionsService : IOptionsService
    {
        public string AppPath { get; set; }
        public string PlatformName { get; set; }
        public string DeviceName { get; set; }

        protected string mArguments;

        public Dictionary<string, object> AdditionalData;

        public OptionsService(string pAppPath, string pPlatformName, string pDeviceName)
        {
            this.AppPath = pAppPath;
            this.PlatformName = pPlatformName;
            this.DeviceName = pDeviceName;
        }

        public void BuildBaseOptions(out Dictionary<string, object> pOptions)
        {
            pOptions = new Dictionary<string, object>();
            pOptions.Add("app", this.AppPath);
            pOptions.Add("platformName", this.PlatformName);
            pOptions.Add("deviceName", this.DeviceName);
        }

        public abstract Dictionary<string, object> ToCapabilities();
    }
}
