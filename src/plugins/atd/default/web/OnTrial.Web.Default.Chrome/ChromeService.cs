using System;
using System.Text;
using OnTrial.Api;

namespace OnTrial.Web.Default.Chrome
{
    public class ChromeService : WebService
    {
        private const string defaultHostName = "localhost";
        private const string defaultExeName = "chromedriver.exe";

        public bool VerboseLogging = false;
        public string LogPath = "";

        public ChromeService() : this(null) { }

        public ChromeService(string pServicePath) : this(pServicePath, null) { }

        public ChromeService(string pServicePath, int? pPort) : this(pServicePath, pPort, defaultHostName, defaultExeName) { }

        public ChromeService(string pServicePath, int? pPort, string pHostName, string pExeName)
            : base(pHostName, pPort, pServicePath, pExeName, new ChromeProtocol())
        {
            this.BuildArguments();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Start()
        {
            base.Start();

            bool isInitialized = false;
            DateTime timeout = DateTime.Now.Add(TimeSpan.FromSeconds(5));
            while (!isInitialized && DateTime.Now < timeout)
            {
                // If the driver service process has exited, we can exit early.
                if (this.mProcess != null && !this.mProcess.HasExited)
                {
                    isInitialized = true;
                    break;
                }
            }
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Stop()
        {
            this.Client.SendRequestAsync(ApiMethod.Get, "/shutdown", "{}");
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
