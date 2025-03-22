using Allure.Net.Commons;
using Microsoft.Extensions.Logging;
using nunit_selenium_automation_reading_journal.Drivers;
using OpenQA.Selenium;

namespace nunit_selenium_automation_reading_journal.Tests
{
    public class LaunchSettings
    {
        protected IWebDriver driver;
        private const string BaseUrl = "http://localhost:8080/";
        private readonly BrowserType browser = BrowserType.Chrome;
     
        [SetUp]
        public void SetUp()
        {
            driver = WebDriverFactory.CreateWebDriver(browser);
            driver.Manage().Window.Maximize();
            driver.Navigate().GoToUrl(BaseUrl);
        }

        [TearDown]
        public void TearDown()
        {
          
                // Додаємо скріншот до звіту Allure
                AllureApi.AddAttachment("screenshot", "image/png", TakeScreenshot());
            
            driver.Dispose();
        }

        private byte[] TakeScreenshot()
        {
            Screenshot screenshot = ((ITakesScreenshot)driver).GetScreenshot();
            return screenshot.AsByteArray;
        }
    }
}
