using Microsoft.Extensions.Logging;

namespace OnTrial.Logger
{
    public class FileLoggerConfiguration
    {
        public LogLevel Level { get; set; }
        public bool LogTime { get; set; } = true;
        public bool Enable { get; set; } = true;
    }
}
