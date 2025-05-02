
namespace nunit_selenium_automation_reading_journal.Core.Logger
{
    public class TestLogEventArgs : EventArgs
    {
        public TestContext TestContext { get; }
        public TimeSpan Duration { get; }

        public TestLogEventArgs(TestContext testContext, TimeSpan duration)
        {
            TestContext = testContext;
            Duration = duration;
        }
    }
}
