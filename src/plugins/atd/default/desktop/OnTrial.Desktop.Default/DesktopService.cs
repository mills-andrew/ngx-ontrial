using OnTrial.Api;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace OnTrial.Desktop.Default
{
    public class DesktopService : IDesktopService
    {
        public ApiClient Client { get; set; }

        public string Arguments { get; set; }
        public string HostName { get; set; }
        public string ServicePath { get; set; }
        public string ExecutableName { get; set; }
        public int Port { get; set; }
        public Uri ToUri => new Uri(string.Format("http://{0}:{1}", this.HostName, this.Port));
        public IProtocolService Protocol { get; set; }

        protected Process mProcess;
        protected Task mTask;
        protected string mData = "Starting Service";

        public virtual void BuildArguments() { }
        public virtual void Start() { }
        public virtual void Stop() { }
    }
}
