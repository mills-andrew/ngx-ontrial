using System.Collections.Generic;
using System.Linq;

namespace OnTrial.Desktop.Default.Windows
{
    public class WindowsOptions : OptionsService
    {
        private const string DefaultPlatformName = "Windows";
        private const string DefaultDeviceName = "WindowsPC";

        public WindowsOptions(string pPath) : base(pPath, DefaultPlatformName, DefaultDeviceName) { }

        public override Dictionary<string, object> ToCapabilities()
        {
            Dictionary<string, object> data;
            BuildBaseOptions(out data);

            if (AdditionalData != null)
                for (int x = 0; x < AdditionalData.Count; x++)
                    data.Add(AdditionalData.ElementAt(x).Key, AdditionalData.ElementAt(x).Value);

            return data;
        }
    }
}
