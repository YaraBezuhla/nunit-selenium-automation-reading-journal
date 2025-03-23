using nunit_selenium_automation_reading_journal.Drivers;
using nunit_selenium_automation_reading_journal.Logger;
using OpenQA.Selenium;

namespace nunit_selenium_automation_reading_journal.Tests
{
    public class LaunchSettings
    {
        protected IWebDriver driver;
        private LoggerConfig _logger;
        private const string BaseUrl = "http://localhost:8080/";
        private readonly BrowserType browser = BrowserType.Chrome;

        [SetUp]
        public void SetUp()
        {
            driver = WebDriverFactory.CreateWebDriver(browser);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BaseUrl);

            _logger = new LoggerConfig(driver);
        }

        [TearDown]
        public void TearDown()
        {
            var testContext = TestContext.CurrentContext;
            _logger.TakeScreenshot(testContext);
            _logger.CaptureLog(testContext);

            driver.Dispose();
        }

    }
}
