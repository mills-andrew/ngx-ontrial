using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnTrial.IOC;

namespace OnTrial.Logger
{
    public static class ConsoleLoggerExtensions
    {
        /// <summary>
        /// Adds a new console logger
        /// </summary>
        /// <param name="pBuilder">The log builder to add to</param>
        /// <returns></returns>
        public static ILoggingBuilder AddConsole(this ILoggingBuilder pBuilder, ConsoleLoggerConfiguration pConfiguration = null)
        {
            // Create default configuration if not provided
            if (pConfiguration == null)
                pConfiguration = new ConsoleLoggerConfiguration();

            // Add file log provider to builder
            pBuilder.AddProvider(new ConsoleLoggerProvider(pConfiguration));

            // Return the builder
            return pBuilder;
        }

        /// <summary>
        /// Injects a console logger into the framework construction
        /// </summary>
        /// <param name="pConstruction">The construction</param>
        /// <returns></returns>
        public static BaseConstruction AddConsoleLogger(this BaseConstruction pConstruction, LogLevel pMinLogLevel = LogLevel.Trace)
        {
            // Make use of AddLogging extension
            pConstruction.Services.AddLogging(options =>
            {
                // Setup loggers from configuration
                options.AddConfiguration(pConstruction.Configuration.GetSection("Logging"));

                // Default to console level
                options.SetMinimumLevel(LogLevel.Trace);

                // Add console logger
                options.AddConsole(new ConsoleLoggerConfiguration() { Level = pMinLogLevel });
            });

            pConstruction.Services.AddTransient(provider => provider.GetService<ILoggerFactory>().CreateLogger("OnTrial"));

            return pConstruction;
        }
    }
}
