using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace nunit_selenium_automation_reading_journal.Drivers
{
    internal class FirefoxDriverFactrory : IDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new FirefoxDriver();
        }
    }
}
