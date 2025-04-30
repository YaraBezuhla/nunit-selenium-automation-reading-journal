using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace nunit_selenium_automation_reading_journal.PageObjects.Pages
{
    public class SearchPageObject
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public SearchPageObject(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

    }
}
