using OpenQA.Selenium;

namespace nunit_selenium_automation_reading_journal.Pages
{
    internal class BasePage
    {
        protected IWebDriver driver;

        public BasePage(IWebDriver driver)
        {
            this.driver = driver;
        }
    }
}
