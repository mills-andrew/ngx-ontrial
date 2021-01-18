using OnTrial.Api;
using OnTrial.Logger;
using OnTrial.Utilities;
using System;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace OnTrial.Desktop.Default.Windows
{
    public class WindowsService : DesktopService
    {
        private const string defaultHostName = "localhost";
        private const string defaultExeName = "WinAppDriver.exe";
        private const int defaultPort = 4723;

        public bool VerboseLogging = false;
        public string LogPath = "";

        public WindowsService(string pHostName = null, int? pPort = null, string pServicePath = null, string pExeName = null)
        {
            base.HostName = pHostName ?? defaultHostName;
            base.Port = pPort ?? defaultPort;
            base.ExecutableName = pExeName ?? defaultExeName;
            base.ServicePath = pServicePath ?? FileUtils.FindFile(base.ExecutableName);
            base.Protocol = new WindowsProtocol();
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Start()
        {
            try
            {
                ProcessStartInfo processInfo = new ProcessStartInfo();
                processInfo.FileName = Path.Combine(ServicePath, ExecutableName);
                processInfo.ErrorDialog = true;
                processInfo.UseShellExecute = false;
                processInfo.CreateNoWindow = true;
                processInfo.RedirectStandardInput = true;
                processInfo.RedirectStandardOutput = true;
                processInfo.RedirectStandardError = true;
                processInfo.WorkingDirectory = ServicePath;
                processInfo.Arguments = Arguments;
                this.mProcess = Process.Start(processInfo);

                //Start a seperate thread to read in the console data, this is needed because the console is placed in a constant reading state, 
                // we can never proceed on this thread if we do. Placing it on a new thread helps push things along.
                mTask = new Task(() => {
                    using (StreamReader reader = mProcess.StandardOutput)
                    {
                        while (reader.Peek() >= 0)
                        {
                            string line = reader.ReadLine();
                            if (line.Length > 0 && line != "\0")
                                mData += "\n" + line;
                        }
                    }
                });
                mTask.Start();
            }
            catch (Exception e)
            {
                Log.Critical("Starting the process encountered an error.", pException: e);
            }

            this.Client.SendRequestAsync(ApiMethod.Get, "/status", "{}");
        }

        /// <summary>
        /// 
        /// </summary>
        public override void Stop()
        {
            Log.Information("Stopping Service");

            this.Client.SendRequestAsync(ApiMethod.Get, "/shutdown", "{}");

            //Make sure to exit before we tell the thread to wait for exit;
            this.mProcess.StandardInput.WriteLine($"exit");
            mTask.Wait();

            if (mData.Replace("\0", string.Empty).Contains("0x80004005"))
                throw new Exception(mData);
            else
                Log.Information(mData);

            this.mProcess.WaitForExit();
            this.mProcess.Dispose();
            this.mProcess = null;
        }

        public override void BuildArguments()
        {
            StringBuilder argsBuilder = new StringBuilder(Arguments);
            argsBuilder.Append(string.Format("{0}", base.Port));

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
