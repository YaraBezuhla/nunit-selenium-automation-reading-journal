using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace nunit_selenium_automation_reading_journal.Drivers
{
    internal class ChromeDriverFactory : IDriverFactory
    {
        public IWebDriver CreateDriver()
        {
            return new ChromeDriver();
        }
    }
}
