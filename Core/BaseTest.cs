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
        protected WebDriverWait wait;
        private readonly AppsettingsJson _settings = ConfigurationProvider.LoadSettings("TestSettings");
        protected IServiceProvider ServiceProvider;
        protected PageProvider Pages; //контейнер
        protected TestLogger _logger;

        [SetUp]
        public void SetUp()
        {
            driver = WebDriverFactory.CreateWebDriver(_settings.Browsers["DefaultBrowser"]);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_settings.Urls["BaseUrl"]);

            var waitHelper = new WaitHelper(driver, _settings.WaitConfig);
            wait = waitHelper.CreateWait();

            _logger = new TestLogger(driver);

            var consoleLogger = new ConsoleLogHandler();
            var allureLogger = new AllureLogHandler(driver);

            consoleLogger.Subscribe(_logger);
            allureLogger.Subscribe(_logger);

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
            _logger.FinalizeLogging();

            driver.Dispose();
                if (ServiceProvider is IDisposable disposable)
                {
                    disposable.Dispose();
                }
            

        }

    }
}
