using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using OnTrial.IOC;
using System;
using System.Runtime.CompilerServices;


namespace OnTrial.Logger
{
    public static class Log
    {
        private static ILogger logger => Framework.Provider?.GetService<ILogger>();

        /// <summary>
        /// Formats the message including the source information pulled out of the state
        /// </summary>
        /// <param name="pState">The state information about the log</param>
        /// <param name="pException">The exception</param>
        /// <returns></returns>
        private static string Format(object[] pState, Exception pException)
        {
            // Get the values from the state
            var origin = (string)pState[0];
            var filePath = (string)pState[1];
            var lineNumber = (int)pState[2];
            var message = (string)pState[3];

            // Get any exception message
            var exceptionMessage = pException?.ToString();

            // If we have an exception ...
            if (pException != null)
                // New line between message and exception
                exceptionMessage = Environment.NewLine + pException;

            // Format the message string
            return $"[{System.IO.Path.GetFileName(filePath)} > {origin}(): {lineNumber}]{Environment.NewLine}{message}{exceptionMessage}";
        }

        /// <summary>
        /// Logs a critical message, including the source of the log
        /// </summary>
        /// <param name="pMessage">The message</param>
        /// <param name="pOrigin">The callers member/function name</param>
        /// <param name="pFilePath">The source code file path</param>
        /// <param name="pLineNumber">The line number in the code file of the caller</param>
        /// <param name="pArgs">The additional arguments</param>
        public static void Critical(
            string pMessage,
            EventId pEventId = new EventId(),
            Exception pException = null,
            [CallerMemberName] string pOrigin = "",
            [CallerFilePath] string pFilePath = "",
            [CallerLineNumber] int pLineNumber = 0,
            params object[] pArgs) => logger?.LogCritical(pEventId, Format(pArgs.Prepend(pOrigin, pFilePath, pLineNumber, pMessage), pException));

        /// <summary>
        /// Logs a verbose trace message, including the source of the log
        /// </summary>
        /// <param name="pMessage">The message</param>
        /// <param name="pOrigin">The callers member/function name</param>
        /// <param name="pFilePath">The source code file path</param>
        /// <param name="pLineNumber">The line number in the code file of the caller</param>
        /// <param name="pArgs">The additional arguments</param>
        public static void Trace(
            string pMessage,
            EventId pEventId = new EventId(),
            Exception pException = null,
            [CallerMemberName] string pOrigin = "",
            [CallerFilePath] string pFilePath = "",
            [CallerLineNumber] int pLineNumber = 0,
            params object[] pArgs) => logger?.LogTrace(pEventId, Format(pArgs.Prepend(pOrigin, pFilePath, pLineNumber, pMessage), pException));

        /// <summary>
        /// Logs a debug message, including the source of the log
        /// </summary>
        /// <param name="pMessage">The message</param>
        /// <param name="pOrigin">The callers member/function name</param>
        /// <param name="pFilePath">The source code file path</param>
        /// <param name="pLineNumber">The line number in the code file of the caller</param>
        /// <param name="pArgs">The additional arguments</param>
        public static void Debug(
            string pMessage,
            EventId pEventId = new EventId(),
            Exception pException = null,
            [CallerMemberName] string pOrigin = "",
            [CallerFilePath] string pFilePath = "",
            [CallerLineNumber] int pLineNumber = 0,
            params object[] pArgs) => logger?.LogDebug(pEventId, Format(pArgs.Prepend(pOrigin, pFilePath, pLineNumber, pMessage), pException));

        /// <summary>
        /// Logs an error message, including the source of the log
        /// </summary>
        /// <param name="pMessage">The message</param>
        /// <param name="pOrigin">The callers member/function name</param>
        /// <param name="pFilePath">The source code file path</param>
        /// <param name="pLineNumber">The line number in the code file of the caller</param>
        /// <param name="pArgs">The additional arguments</param>
        public static void Error(
            string pMessage,
            EventId pEventId = new EventId(),
            Exception pException = null,
            [CallerMemberName] string pOrigin = "",
            [CallerFilePath] string pFilePath = "",
            [CallerLineNumber] int pLineNumber = 0,
            params object[] pArgs) => logger?.LogError(pEventId, Format(pArgs.Prepend(pOrigin, pFilePath, pLineNumber, pMessage), pException));

        /// <summary>
        /// Logs an informative message, including the source of the log
        /// </summary>
        /// <param name="pMessage">The message</param>
        /// <param name="pOrigin">The callers member/function name</param>
        /// <param name="pFilePath">The source code file path</param>
        /// <param name="pLineNumber">The line number in the code file of the caller</param>
        /// <param name="pArgs">The additional arguments</param>
        public static void Information(
            string pMessage,
            EventId pEventId = new EventId(),
            Exception pException = null,
            [CallerMemberName] string pOrigin = "",
            [CallerFilePath] string pFilePath = "",
            [CallerLineNumber] int pLineNumber = 0,
            params object[] pArgs) => logger?.LogInformation(pEventId, Format(pArgs.Prepend(pOrigin, pFilePath, pLineNumber, pMessage), pException));

        /// <summary>
        /// Logs a warning message, including the source of the log
        /// </summary>
        /// <param name="pMessage">The message</param>
        /// <param name="pOrigin">The callers member/function name</param>
        /// <param name="pFilePath">The source code file path</param>
        /// <param name="pLineNumber">The line number in the code file of the caller</param>
        /// <param name="pArgs">The additional arguments</param>
        public static void Warning(
            string pMessage,
            EventId pEventId = new EventId(),
            Exception pException = null,
            [CallerMemberName] string pOrigin = "",
            [CallerFilePath] string pFilePath = "",
            [CallerLineNumber] int pLineNumber = 0,
            params object[] pArgs) => logger?.LogWarning(pEventId, Format(pArgs.Prepend(pOrigin, pFilePath, pLineNumber, pMessage), pException));
    }
}