using OnTrial.Api;
using OnTrial.Utilities;
using System;
using System.Diagnostics;
using System.IO;
using System.Security.Permissions;

namespace OnTrial.Web.Default
{
    public class WebService : IWebService
    {
        #region Public Variables

        public ApiClient Client { get; set; }

        public string Arguments { get; set; }
        public string HostName { get; set; }
        public string ServicePath { get; set; }
        public string ExecutableName { get; set; }
        public int Port { get; set; }

        public Uri ToUri => new Uri(string.Format("http://{0}:{1}", this.HostName, this.Port));

        public IProtocolService Protocol { get; set; }

        #endregion

        protected Process mProcess;
        #region Constructor(s)

        public WebService(string pHostName, int? pPort, string pServicePath, string pExeName, ProtocolService pProtocol)
        {
            this.HostName = pHostName ?? throw new ArgumentNullException(nameof(pHostName));
            this.Port = pPort ?? PortUtils.OpenPort;
            this.ExecutableName = pExeName ?? throw new ArgumentNullException(nameof(pExeName));
            this.ServicePath = pServicePath ?? FileUtils.FindFile(this.ExecutableName);
            this.Protocol = pProtocol ?? throw new ArgumentNullException(nameof(pHostName));
        }

        #endregion

        #region Public Method(s)

        public virtual void BuildArguments() { }

        [SecurityPermission(SecurityAction.Demand)]
        public virtual void Start()
        {
            this.mProcess = new Process();
            this.mProcess.StartInfo.FileName = Path.Combine(ServicePath, ExecutableName);
            this.mProcess.StartInfo.Arguments = Arguments;
            this.mProcess.StartInfo.UseShellExecute = false;
            this.mProcess.StartInfo.CreateNoWindow = true;
            this.mProcess.Start();
        }

        [SecurityPermission(SecurityAction.Demand)]
        public virtual void Stop()
        {
            this.mProcess.Kill();
            this.mProcess.Dispose();
            this.mProcess = null;
        }

        #endregion
    }
}
