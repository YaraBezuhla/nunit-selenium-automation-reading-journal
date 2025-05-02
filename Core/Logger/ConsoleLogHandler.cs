namespace nunit_selenium_automation_reading_journal.Core.Logger
{
    public class ConsoleLogHandler
    {
        public void Subscribe(TestLogger logger)
        {
            logger.OnTestFailed += HandleLog;
        }

        private void HandleLog(object? sender, TestLogEventArgs e)
        {
            Console.WriteLine("=== Test Failed ===");
            Console.WriteLine($"Status: {e.TestContext.Result.Outcome.Status}");
            Console.WriteLine($"Error: {e.TestContext.Result.Message}");
            Console.WriteLine($"Duration: {e.Duration}");
        }
    }
}
