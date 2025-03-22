using nunit_selenium_automation_reading_journal.Drivers;
using OpenQA.Selenium;

namespace nunit_selenium_automation_reading_journal.Tests
{
    public class LaunchSettings
    {
        protected IWebDriver driver;
        private const string BaseUrl = "http://localhost:8080/";
        private readonly BrowserType browser = BrowserType.Chrome;

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
            driver.Dispose();
        }
    }
}
