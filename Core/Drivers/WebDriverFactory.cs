using OpenQA.Selenium;

namespace nunit_selenium_automation_reading_journal.Core.Drivers
{
    public static class WebDriverFactory
    {
        public static IWebDriver CreateWebDriver(string browserName)
        {
            return browserName.Trim().ToLower() switch
            {
                "chrome" => new ChromeDriverFactory().CreateDriver(),
                "firefox" => new FirefoxDriverFactory().CreateDriver(),
                _ => throw new ArgumentException($"Unsupported browser: {browserName}")
            };
        }
    }
}
