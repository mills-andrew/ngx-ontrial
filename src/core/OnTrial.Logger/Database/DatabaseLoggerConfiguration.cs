using Microsoft.Extensions.Logging;

namespace OnTrial.Logger
{
    public class DatabaseLoggerConfiguration
    {
        public LogLevel Level { get; set; }
        public bool LogTime { get; set; } = true;
        public bool Enable { get; set; } = true;
    }
}
