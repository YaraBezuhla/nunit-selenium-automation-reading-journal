using Microsoft.Extensions.Logging;

namespace nunit_selenium_automation_reading_journal.Logs
{
    public class LoggerFactoryManager
    {
        private static ILoggerFactory _loggerFactory;

        public static void Initialize()
        {
            _loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
              
            });
        }

        public static ILogger<T> CreateLogger<T>() => _loggerFactory.CreateLogger<T>();
        public static void Dispose() => _loggerFactory?.Dispose();
    }
}
