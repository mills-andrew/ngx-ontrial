using OnTrial.Api;
using System;
using System.Text;

namespace OnTrial.Web.Default.IE
{
    public class IEService : WebService
    {
        private const string defaultHostName = "localhost";
        private const string defaultExeName = "IEDriverServer.exe";

        public bool VerboseLogging = false;
        public string LogPath = "";

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pHostName"></param>
        /// <param name="pPort"></param>
        /// <param name="pServicePath"></param>
        /// <param name="pExeName"></param>
        public IEService() : this(null) { }

        public IEService(string pServicePath) : this(pServicePath, null) { }

        public IEService(string pServicePath, int? pPort) : this(pServicePath, pPort, defaultHostName, defaultExeName) { }

        public IEService(string pServicePath, int? pPort, string pHostName, string pExeName)
            : base(pHostName, pPort, pServicePath, pExeName, new IEProtocol())
        {
            this.BuildArguments();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Start()
        {
            base.Start();
            this.Client.SendRequestAsync(ApiMethod.Get, new Uri(this.ToUri, "/status").ToString(), "{}");
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Stop()
        {
            this.Client.SendRequestAsync(ApiMethod.Post, new Uri(this.ToUri, "/shutdown").ToString(), "{}");
            base.Stop();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void BuildArguments()
        {
            StringBuilder argsBuilder = new StringBuilder(Arguments);

            argsBuilder.Append(string.Format("--port={0}", base.Port));

            if (this.VerboseLogging)
            {
                argsBuilder.Append(" --verbose");

                if (!string.IsNullOrEmpty(this.LogPath))
                    argsBuilder.AppendFormat(string.Format(" --log-path=\"{0}\"", LogPath));
            }

            Arguments = argsBuilder.ToString();
        }
    }
}
