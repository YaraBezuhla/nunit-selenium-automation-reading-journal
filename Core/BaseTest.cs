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
        private static readonly AppsettingsJson _settings = ConfigurationProvider.LoadSettings("TestSettings");
        protected IServiceProvider ServiceProvider;
        protected PageProvider Pages;
        protected TestLogger _logger;

        [SetUp]
        public void SetUp()
        {
            driver = WebDriverFactory.CreateWebDriver(_settings.Browsers["DefaultBrowser"]);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(_settings.Urls["BaseUrl"]);

            InitWait();
            InitLoggers();
            InitProvider();
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

        private void InitLoggers()
        {
            _logger = new TestLogger(driver);
            new ConsoleLogHandler().Subscribe(_logger);
            new AllureLogHandler(driver).Subscribe(_logger);
        }

        private void InitProvider()
        {
            var services = new ServiceCollection();
            services.AddSingleton(driver);
            services.AddSingleton(wait);
            PageProvider.RegisterPages(services);
            ServiceProvider = services.BuildServiceProvider();
            Pages = new PageProvider(ServiceProvider);
        }

        private void InitWait()
        {
            var waitHelper = new WaitHelper(driver, _settings.WaitConfig);
            wait = waitHelper.CreateWait();
        }

    }
}
