using OnTrial.Api;
using System;
using System.Security.Permissions;

namespace OnTrial.Web
{
    public interface IWebService
    {
        #region Public Variables

        ApiClient Client { get; set; }

        public string Arguments { get; set; }
        public string HostName { get; set; }
        public string ServicePath { get; set; }
        public string ExecutableName { get; set; }
        public int Port { get; set; }
        public IProtocolService Protocol { get; set; }

        Uri ToUri => new Uri(string.Format("http://{0}:{1}", this.HostName, this.Port));
        
        public void BuildArguments();

        #endregion

        #region Public Method(s)

        [SecurityPermission(SecurityAction.Demand)]
        public void Start();

        [SecurityPermission(SecurityAction.Demand)]
        public void Stop();

        #endregion
    }
}
