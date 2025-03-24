using nunit_selenium_automation_reading_journal.Drivers;
using nunit_selenium_automation_reading_journal.Logger;
using nunit_selenium_automation_reading_journal.Settings;
using nunit_selenium_automation_reading_journal.Settings.WaitSettings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace nunit_selenium_automation_reading_journal.Tests
{
    public class LaunchSettings
    {
        protected IWebDriver driver;
        private LoggerConfig _logger;
        public WebDriverWait wait;
        private readonly AppsettingsJson _settings = ConfigurationProvider.LoadSettings();

        [SetUp]
        public void SetUp()
        {
            driver = WebDriverFactory.CreateWebDriver(Enum.Parse<BrowserType>(_settings.Browsers["DefaultBrowser"], true));
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_settings.Urls["BaseUrl"]);

            //   wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));

            // Ініціалізація WaitHelper з кастомними налаштуваннями
            var waitHelper = new WaitHelper(driver, _settings.WaitConfig);
            wait = waitHelper.CreateWait();

            _logger = new LoggerConfig(driver);
        }

        [TearDown]
        public void TearDown()
        {
            var testContext = TestContext.CurrentContext;
            if (testContext.Result.Outcome.Status != NUnit.Framework.Interfaces.TestStatus.Passed)
            { 
                _logger.TakeScreenshot(testContext);
                _logger.CaptureLog(testContext);
            }

            driver.Dispose();
        }

    }
}
