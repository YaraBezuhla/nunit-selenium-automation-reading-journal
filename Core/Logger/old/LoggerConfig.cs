using Allure.Net.Commons;
using OpenQA.Selenium;
using System.Text;

namespace nunit_selenium_automation_reading_journal.Core.Logger.old
{
    internal class LoggerConfig
    {
        private readonly IWebDriver _driver;
        private readonly DateTime _startTime;

        public LoggerConfig(IWebDriver driver)
        {
            _driver = driver;
            _startTime = DateTime.Now;
        }

        public void CaptureLog(TestContext testContext)
        {
            var duration = DateTime.Now - _startTime;
            string environmentInfo = $"OS: {Environment.OSVersion}";

            AllureApi.AddAttachment("Environment Info", "text/plain", Encoding.UTF8.GetBytes(environmentInfo));

            string errorMessage = $"Status: {testContext.Result.Outcome.Status}\nError: {testContext.Result.Message}\nTime: {duration}";
            AllureApi.AddAttachment("Test Logs", "text/plain", Encoding.UTF8.GetBytes(errorMessage));
        }

        public void TakeScreenshot(TestContext testContext)
        {
            Screenshot screenshot = ((ITakesScreenshot)_driver).GetScreenshot();
            AllureApi.AddAttachment("screenshot", "image/png", screenshot.AsByteArray);

        }
    }
}
