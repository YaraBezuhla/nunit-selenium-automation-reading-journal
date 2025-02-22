using nunit_selenium_automation_reading_journal.Drivers;
using OpenQA.Selenium;

namespace nunit_selenium_automation_reading_journal.Tests
{
    public class LaunchSettings
    {
        protected IWebDriver Driver;
        private const string BaseUrl = "http://localhost:8080/";
        private readonly BrowserType browser = BrowserType.Chrome;

        [SetUp]
        public void SetUp()
        {
            Driver = WebDriverFactory.CreateWebDriver(browser);
            Driver.Manage().Window.Maximize();
            Driver.Navigate().GoToUrl(BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
            Driver.Dispose();
        }
    }
}
