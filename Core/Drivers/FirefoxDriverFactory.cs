using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using WebDriverManager;
using WebDriverManager.DriverConfigs.Impl;

namespace nunit_selenium_automation_reading_journal.Core.Drivers
{
    public class FirefoxDriverFactory : IDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            new DriverManager().SetUpDriver(new FirefoxConfig());
            return new FirefoxDriver();
        }

    }
}
