using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnTrial.IOC;

namespace OnTrial.Logger
{
    public static class DatabaseLoggerExtensions
    {
        /// <summary>
        /// Adds a new database logger to the specific path
        /// </summary>
        /// <param name="pBuilder">The log builder to add to</param>
        /// <param name="pDatasource">The data source where to write to</param>
        /// <returns></returns>
        public static ILoggingBuilder AddDatabase(this ILoggingBuilder pBuilder, string pDatasource, DatabaseLoggerConfiguration pConfiguration = null)
        {
            // Create default configuration if not provided
            if (pConfiguration == null)
                pConfiguration = new DatabaseLoggerConfiguration();

            // Add database log provider to builder
            pBuilder.AddProvider(new DatabaseLoggerProvider(pDatasource, pConfiguration));

            // Return the builder
            return pBuilder;
        }

        /// <summary>
        /// Injects a file logger into the framework construction
        /// </summary>
        /// <param name="pConstruction">The construction</param>
        /// <param name="logPath">The path of the file to log to</param>
        /// <param name="logTop">Whether to display latest logs at the top of the file</param>
        /// <returns></returns>
        public static BaseConstruction AddDatabaseLogger(this BaseConstruction pConstruction, string pDataSource)
        {
            // Make use of AddLogging extension
            pConstruction.Services.AddLogging(options =>
            {
                // Setup loggers from configuration
                options.AddConfiguration(pConstruction.Configuration.GetSection("Logging"));

                // Default to debug level
                options.SetMinimumLevel(LogLevel.Debug);

                // Add database logger
                options.AddDatabase(pDataSource, new DatabaseLoggerConfiguration());
            });

            // Chain the construction
            return pConstruction;
        }
    }
}
