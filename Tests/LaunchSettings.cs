using Allure.Net.Commons;
using Microsoft.Extensions.Logging;
using nunit_selenium_automation_reading_journal.Drivers;
using OpenQA.Selenium;

namespace nunit_selenium_automation_reading_journal.Tests
{
    public class LaunchSettings
    {
        protected IWebDriver driver;
        private const string BaseUrl = "http://localhost:8080/";
        private readonly BrowserType browser = BrowserType.Chrome;

        private static ILogger _logger;

        static LaunchSettings()
        {
            using var loggerFactory = LoggerFactory.Create(builder =>
            {
                builder.AddConsole();
                builder.AddDebug();
            });

            _logger = loggerFactory.CreateLogger("<LaunchSettings");
          // _logger = loggerFactory.CreateLogger<LaunchSettings>();
        }

        [SetUp]
        public void SetUp()
        {
            driver = WebDriverFactory.CreateWebDriver(browser);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            var testContext = TestContext.CurrentContext;
            if (testContext.Result.Outcome.Status == NUnit.Framework.Interfaces.TestStatus.Failed)
            {
                _logger.LogError($"Test Failed: {testContext.Test.Name} - {testContext.Result.Message}");
                AllureApi.AddAttachment("Test Log", "text/plain", "log.txt");
            }
          
            driver.Quit();
            driver.Dispose();
        }
    }
}
