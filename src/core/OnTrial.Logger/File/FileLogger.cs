using System;
using System.Collections.Concurrent;
using System.IO;
using Microsoft.Extensions.Logging;

namespace OnTrial.Logger
{
    public class FileLogger : ILogger
    {
        protected static object mFileLock = new object();
        protected static ConcurrentDictionary<string, object> mFileLocks = new ConcurrentDictionary<string, object>();

        protected readonly string mCategoryName;
        protected readonly string mFileName, mFilePath, mDirectory;
        protected FileLoggerConfiguration mConfiguration;

        public FileLogger(string pCategoryName, string pFilePath, FileLoggerConfiguration pConfiguration)
        {
            pFilePath = Path.GetFullPath(pFilePath);

            mCategoryName = pCategoryName;
            mFilePath = pFilePath;
            mDirectory = Path.GetDirectoryName(pFilePath);
            mConfiguration = pConfiguration;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="pLogLevel"></param>
        /// <returns></returns>
        public bool IsEnabled(LogLevel pLogLevel)
        {
            return pLogLevel >= mConfiguration.Level;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <typeparam name="TState"></typeparam>
        /// <param name="pLogLevel"></param>
        /// <param name="pEventId"></param>
        /// <param name="pState"></param>
        /// <param name="pException"></param>
        /// <param name="pFormatter"></param>
        public void Log<TState>(LogLevel pLogLevel, EventId eventId, TState pState, Exception pException, Func<TState, Exception, string> pFormatter)
        {
            if (IsEnabled(pLogLevel) == false)
                return;

            // Get the current time
            var currentTime = DateTimeOffset.Now.ToString("yyyy-MM-dd hh:mm:ss");

            // Prepend log level
            var logLevel = $"{pLogLevel.ToString().ToUpper()}";

            // Prepend the time of the log
            var timeLog = $"[{currentTime}]";

            // Get the formatted message string
            var message = pFormatter(pState, pException);

            // Write the message
            var output = $"{logLevel}{timeLog}{message}{Environment.NewLine}";

            var normalizedPath = mFilePath.ToUpper();

            var fileLock = default(object);

            // Double saftey check even though the file locks should be thread safe
            lock (mFileLock)
            {
                // Get the file lock based on the normalied path
                fileLock = mFileLocks.GetOrAdd(normalizedPath, path => new object());
            }

            lock (fileLock)
            {
                if (!Directory.Exists(mDirectory))
                    Directory.CreateDirectory(mDirectory);

                //Open the file in question
                using (var fileStream = new StreamWriter(File.Open(mFilePath, FileMode.OpenOrCreate, FileAccess.ReadWrite, FileShare.ReadWrite)))
                {
                    fileStream.BaseStream.Seek(0, SeekOrigin.End);
                    fileStream.Write(output);
                }
            }
        }
    }
}
