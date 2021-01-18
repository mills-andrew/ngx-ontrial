using System.Collections.Generic;

namespace OnTrial.Web.Default.Chrome
{
    public class ChromeOptions : OptionsService
    {
        private const string DefaultPlatformName = "windows";
        private const string DefaultBrowserName = "chrome";
        private const string DefaultCapabilityKey = "goog:chromeOptions";

        public List<string> Arguments;
        public bool StartMaximized = true;

        public ChromeOptions() : base(DefaultPlatformName, DefaultBrowserName, DefaultCapabilityKey) { }

        public override Dictionary<string, object> ToCapabilities()
        {
            Dictionary<string, object> options, additionalOptions;
            BuildBaseOptions(out options);
            BuildAdditionalOptions(out additionalOptions);

            if (additionalOptions.IsNullOrEmpty() == false)
                options.Set(CapabilityKey, additionalOptions);

            return options;
        }

        private void BuildAdditionalOptions(out Dictionary<string, object> pOptions)
        {
            pOptions = new Dictionary<string, object>();
            Arguments = new List<string>();

            if (this.StartMaximized)
                Arguments.Add("--start-maximized");
        }
    }
}
