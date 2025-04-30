using Microsoft.Extensions.DependencyInjection;
using nunit_selenium_automation_reading_journal.Core.Drivers;
using nunit_selenium_automation_reading_journal.PageObjects;
using nunit_selenium_automation_reading_journal.Core.WaitSettings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using nunit_selenium_automation_reading_journal.Core.Config;
using nunit_selenium_automation_reading_journal.Core.Logger;

namespace nunit_selenium_automation_reading_journal.Core
{
    public class BaseTest
    {
        protected IWebDriver driver;
        private LoggerConfig _logger;
        protected WebDriverWait wait;
        private readonly AppsettingsJson _settings = ConfigurationProvider.LoadSettings("TestSettings");
        protected IServiceProvider ServiceProvider;
        protected PageProvider Pages; //контейнер

        [SetUp]
        public void SetUp()
        {
            driver = WebDriverFactory.CreateWebDriver(_settings.Browsers["DefaultBrowser"]);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_settings.Urls["BaseUrl"]);

            var waitHelper = new WaitHelper(driver, _settings.WaitConfig);
            wait = waitHelper.CreateWait();

            _logger = new LoggerConfig(driver);

            var services = new ServiceCollection();
            services.AddSingleton(driver);
            services.AddSingleton(wait);
            PageProvider.RegisterPages(services);
            ServiceProvider = services.BuildServiceProvider();
            Pages = new PageProvider(ServiceProvider);
        }

        [TearDown]
        public void TearDown()
        {
            try
            {
                var testContext = TestContext.CurrentContext;
                if (testContext.Result.Outcome.Status != NUnit.Framework.Interfaces.TestStatus.Passed)
                {
                    _logger.TakeScreenshot(testContext);
                    _logger.CaptureLog(testContext);
                }

            }
            finally
            {
                driver.Dispose();
                if (ServiceProvider is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            }

        }

    }
}
