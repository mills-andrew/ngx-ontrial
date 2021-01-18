using System.Collections.Generic;

namespace OnTrial.Desktop
{
    public interface IOptionsService
    {
        public string AppPath { get; set; }
        public string PlatformName { get; set; }
        public string DeviceName { get; set; }
        
        public Dictionary<string, object> ToCapabilities();
        public void BuildBaseOptions(out Dictionary<string, object> pOptions);
    }
}
