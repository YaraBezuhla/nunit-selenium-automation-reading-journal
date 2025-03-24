using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;

namespace nunit_selenium_automation_reading_journal.Settings.WaitSettings
{
    public class WaitHelper
    {
        private readonly IWebDriver _driver;
        private readonly WaitConfig _config;

        public WaitHelper(IWebDriver driver, WaitConfig config)
        {
            _driver = driver;
            _config = config;
        }

        public WebDriverWait CreateWait()
        {
            var wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(_config.TimeoutSeconds))
            {
                PollingInterval = TimeSpan.FromMilliseconds(_config.PollingIntervalMilliseconds)
            };

            wait.IgnoreExceptionTypes(_config.IgnoredExceptions);
            return wait;
        }
    }
}
