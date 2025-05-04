using OpenQA.Selenium;

namespace nunit_selenium_automation_reading_journal.Core.WaitSettings
{
    public class WaitConfig
    {
        public int TimeoutSeconds { get; set; } = 10; // Загальний таймаут
        public int PollingIntervalMilliseconds { get; set; } = 500; // Інтервал опитування
        public Type[] IgnoredExceptions { get; set; } = new Type[] { typeof(NoSuchElementException) };
    }
}
