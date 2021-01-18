using OnTrial.Api;
using System;

namespace OnTrial.Desktop
{
    public interface IDesktopService
    {
        public ApiClient Client { get; set; }

        public string Arguments { get; set; }
        public string HostName { get; set; }
        public string ServicePath { get; set; }
        public string ExecutableName { get; set; }
        public int Port { get; set; }
        public Uri ToUri => new Uri(string.Format("http://{0}:{1}", this.HostName, this.Port));
        public IProtocolService Protocol { get; set; }

        public void BuildArguments();

        public void Start();
        public void Stop();
    }
}
