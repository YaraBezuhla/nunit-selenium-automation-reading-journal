using nunit_selenium_automation_reading_journal.Core.Config;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;

namespace nunit_selenium_automation_reading_journal.Core.WaitSettings
{
    public static class WaitExtensions
    {
        private static int _timeoutSeconds = ConfigurationProvider.LoadSettings("TestSettings").WaitConfig.TimeoutSeconds;

        public static IWebElement WaitUntilVisible(this IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_timeoutSeconds));
            return wait.Until(ExpectedConditions.ElementIsVisible(locator));
        }

        public static IList<IWebElement> WaitUntilAllVisible(this IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_timeoutSeconds));
            return wait.Until(ExpectedConditions.VisibilityOfAllElementsLocatedBy(locator));
        }

        public static IWebElement WaitUntilClickable(this IWebDriver driver, By locator)
        {
            var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(_timeoutSeconds));
            return wait.Until(ExpectedConditions.ElementToBeClickable(locator));
        }

    }
}
