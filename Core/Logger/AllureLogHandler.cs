using Allure.Net.Commons;
using OpenQA.Selenium;
using System.Text;

namespace nunit_selenium_automation_reading_journal.Core.Logger
{
    public class AllureLogHandler
    {
        private readonly IWebDriver _driver;

        public AllureLogHandler(IWebDriver driver)
        {
            _driver = driver;
        }

        public void Subscribe(TestLogger logger)
        {
            logger.OnTestFailed += HandleLog;
        }

        private void HandleLog(object? sender, TestLogEventArgs e)
        {
            AllureApi.AddAttachment("Current URL", "text/plain", Encoding.UTF8.GetBytes(_driver.Url));

            string envInfo = $"OS: {Environment.OSVersion}";
            AllureApi.AddAttachment("Environment Info", "text/plain", Encoding.UTF8.GetBytes(envInfo));

            string errorInfo = $"Status: {e.TestContext.Result.Outcome.Status}\nError: {e.TestContext.Result.Message}\nTime: {e.Duration}";
            AllureApi.AddAttachment("Test Logs", "text/plain", Encoding.UTF8.GetBytes(errorInfo));

            var screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            AllureApi.AddAttachment("Screenshot", "image/png", screenshot.AsByteArray);
        }
    }
}
