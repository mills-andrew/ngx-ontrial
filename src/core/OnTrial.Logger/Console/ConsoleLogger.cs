using Microsoft.Extensions.Logging;
using System;

namespace OnTrial.Logger
{
    public class ConsoleLogger : ILogger
    {
        protected readonly string mCategoryName;
        protected ConsoleLoggerConfiguration mConfiguration;

        public ConsoleLogger(string pCategoryName, ConsoleLoggerConfiguration pConfiguration)
        {
            mCategoryName = pCategoryName;
            mConfiguration = pConfiguration;
        }

        public IDisposable BeginScope<TState>(TState state)
        {
            throw new NotImplementedException();
        }

        public bool IsEnabled(LogLevel pLogLevel)
        {
            return pLogLevel >= mConfiguration.Level;
        }

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
            var output = $"{logLevel} {timeLog}{Environment.NewLine}{message}{Environment.NewLine}";

            // Write the message to the console
            Console.WriteLine(output);
        }
    }
}
