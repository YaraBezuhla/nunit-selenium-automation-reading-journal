using OpenQA.Selenium;

namespace nunit_selenium_automation_reading_journal.Core.Drivers
{
    public interface IDriverFactory
    {
        IWebDriver CreateDriver();
    }
}
