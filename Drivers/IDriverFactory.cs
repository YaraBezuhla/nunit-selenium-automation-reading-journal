using OpenQA.Selenium;

namespace nunit_selenium_automation_reading_journal.Drivers
{
    public interface IDriverFactory
    {
        IWebDriver CreateDriver();
    }
}
