using OpenQA.Selenium;

namespace nunit_selenium_automation_reading_journal.Core.Logger
{
    public class TestLogger
    {

        private readonly IWebDriver _driver;
        private readonly DateTime _startTime;

        public event EventHandler<TestLogEventArgs>? OnTestFailed;

        public TestLogger(IWebDriver driver)
        {
            _driver = driver;
            _startTime = DateTime.Now;
        }

        public void FinalizeLogging()
        {
            var context = TestContext.CurrentContext;
            var duration = DateTime.Now - _startTime;

            if (context.Result.Outcome.Status != NUnit.Framework.Interfaces.TestStatus.Passed)
            {
                OnTestFailed?.Invoke(this, new TestLogEventArgs(context, duration));
            }
        }

    }
}
