using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnTrial.IOC;

namespace OnTrial.Logger
{
    public static class FileLoggerExtensions
    {
        /// <summary>
        /// Adds a new file logger to the specific path
        /// </summary>
        /// <param name="pBuilder">The log builder to add to</param>
        /// <param name="pPath">The path where to write to</param>
        /// <returns></returns>
        public static ILoggingBuilder AddFile(this ILoggingBuilder pBuilder, string pPath, FileLoggerConfiguration pConfiguration = null)
        {
            // Create default configuration if not provided
            if (pConfiguration == null)
                pConfiguration = new FileLoggerConfiguration();

            // Add file log provider to builder
            pBuilder.AddProvider(new FileLoggerProvider(pPath, pConfiguration));

            // Return the builder
            return pBuilder;
        }

        /// <summary>
        /// Injects a file logger into the framework construction
        /// </summary>
        /// <param name="pConstruction">The construction</param>
        /// <param name="pLogPath">The path of the file to log to</param>
        /// <returns></returns>
        public static BaseConstruction AddFileLogger(this BaseConstruction pConstruction, string pLogPath = "log.txt")
        {
            // Make use of AddLogging extension
            pConstruction.Services.AddLogging(options =>
            {
                // Setup loggers from configuration
                options.AddConfiguration(pConstruction.Configuration.GetSection("Logging"));

                // Default to debug level
                options.SetMinimumLevel(LogLevel.Debug);

                // Add file logger
                options.AddFile(pLogPath, new FileLoggerConfiguration());
            });

            pConstruction.Services.AddTransient(provider => provider.GetService<ILoggerFactory>().CreateLogger("OnTrial"));

            // Chain the construction
            return pConstruction;
        }
    }
}
