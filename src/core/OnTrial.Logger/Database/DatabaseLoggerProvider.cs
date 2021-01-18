using Microsoft.Extensions.Logging;
using System.Collections.Concurrent;

namespace OnTrial.Logger
{
    /// <summary>
    /// Provides the ability to log to file
    /// </summary>
    public class DatabaseLoggerProvider : ILoggerProvider
    {
        #region Protected Members

        /// <summary>
        /// The path to log to
        /// </summary>
        protected string mDataSource;

        /// <summary>
        /// The configuration to use when creating loggers
        /// </summary>
        protected readonly DatabaseLoggerConfiguration mConfiguration;

        /// <summary>
        /// Keeps track of the loggers already created
        /// </summary>
        protected readonly ConcurrentDictionary<string, DatabaseLogger> mLoggers = new ConcurrentDictionary<string, DatabaseLogger>();

        #endregion

        #region Constructor

        /// <summary>
        /// Default constructor
        /// </summary>
        /// <param name="path">The path to log to</param>
        /// <param name="configuration">The configuration to use</param>
        public DatabaseLoggerProvider(string path, DatabaseLoggerConfiguration configuration)
        {
            mConfiguration = configuration;
            mDataSource = path;
        }

        #endregion

        #region ILoggerProvider Implementation

        /// <summary>
        /// Creates a file logger based on the category name
        /// </summary>
        /// <param name="categoryName">The category name of this logger</param>
        /// <returns></returns>
        public ILogger CreateLogger(string categoryName)
        {
            // Get or create the logger for this category
            return mLoggers.GetOrAdd(categoryName, name => new DatabaseLogger(name, mDataSource, mConfiguration));
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
