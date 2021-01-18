using Microsoft.Extensions.Logging;
using System;
using System.Collections.Concurrent;

namespace OnTrial.Logger
{
    public class DatabaseLogger : ILogger
    {
        protected static object mFileLock = new object();
        protected static ConcurrentDictionary<string, object> mFileLocks = new ConcurrentDictionary<string, object>();

        protected readonly string mCategoryName;
        protected readonly string mDataSource;
        protected DatabaseLoggerConfiguration mConfiguration;

        public DatabaseLogger(string pCategoryName, string pDatasource, DatabaseLoggerConfiguration pConfiguration)
        {
            mCategoryName = pCategoryName;
            mDataSource = pDatasource;
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
        public void Log<TState>(LogLevel pLogLevel, EventId pEventId, TState pState, Exception pException, Func<TState, Exception, string> pFormatter)
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

            //SqlUtils.Insert(mDataSource, "dbo.Logs", new object[] { pEventId, currentTime, logLevel, message });
        }
    }
}