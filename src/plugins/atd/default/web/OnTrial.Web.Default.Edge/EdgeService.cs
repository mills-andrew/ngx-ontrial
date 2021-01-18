using System;
using System.Text;
using OnTrial.Api;

namespace OnTrial.Web.Default.Edge
{
    public class EdgeService : WebService
    {
        private const string defaultHostName = "localhost";
        private const string defaultExeName = "msedgedriver.exe";

        public bool VerboseLogging = false;
        public string LogPath = "";

        public EdgeService() : this(null) { }

        public EdgeService(string pServicePath) : this(pServicePath, null) { }

        public EdgeService(string pServicePath, int? pPort) : this(pServicePath, pPort, defaultHostName, defaultExeName) { }

        public EdgeService(string pServicePath, int? pPort, string pHostName, string pExeName)
            : base(pHostName, pPort, pServicePath, pExeName, new EdgeProtocol())
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
