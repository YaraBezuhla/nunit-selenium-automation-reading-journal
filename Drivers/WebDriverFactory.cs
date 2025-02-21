using OpenQA.Selenium;

namespace nunit_selenium_automation_reading_journal.Drivers
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(BrowserType browserType)
        {
            IDriverFactory factory = browserType switch
            {
                BrowserType.Firefox => new FirefoxDriverFactrory(),
                _ => new ChromeDriverFactory(),
            };
            return factory.CreateDriver();
        }
    }
}
