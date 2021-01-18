using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace OnTrial.Logger
{
    /// <summary>
    /// Provides the ability to log to file
    /// </summary>
    public class ConsoleLoggerProvider : ILoggerProvider
    {
        #region Protected Members

        /// <summary>
        /// The configuration to use when creating loggers
        /// </summary>
        protected readonly ConsoleLoggerConfiguration mConfiguration;

        /// <summary>
        /// Keeps track of the loggers already created
        /// </summary>
        protected readonly ConcurrentDictionary<string, ConsoleLogger> mLoggers = new ConcurrentDictionary<string, ConsoleLogger>();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="configuration">The configuration to use</param>
        public ConsoleLoggerProvider(ConsoleLoggerConfiguration configuration)
        {
            mConfiguration = configuration;
        }

        #endregion

        #region ILoggerProvider Implementation

        /// <summary>
        /// Creates a file logger based on the category name
        /// </summary>
        /// <param name="pCategoryName">The category name of this logger</param>
        /// <returns></returns>
        public ILogger CreateLogger(string pCategoryName)
        {
            // Get or create the logger for this category
            return mLoggers.GetOrAdd(pCategoryName, name => new ConsoleLogger(name, mConfiguration));
        }

        /// <summary>
        /// Dispose
        /// </summary>
        public void Dispose()
        {
            mLoggers.Clear();
        }

        #endregion
    }
}
