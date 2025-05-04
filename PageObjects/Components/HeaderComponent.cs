using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Allure.NUnit.Attributes;
using nunit_selenium_automation_reading_journal.Core.WaitSettings;

namespace nunit_selenium_automation_reading_journal.PageObjects.Components
{
    public class HeaderComponent
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public HeaderComponent(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IWebElement GoToAddBookPage() => _driver.FindElement(By.XPath("//a[@data-test='add-book-link']"));

        [AllureStep("Go to Add Book page")]
        public void GoToAddBook() => GoToAddBookPage().Click();

        public IWebElement LoginInHeader => _driver.FindElement(By.ClassName("auth-btn"));

        [AllureStep("Click on login btn")]
        public void ClickLoginInHeader() => LoginInHeader.Click();

        public IWebElement BurgerInHeader => _driver.WaitUntilClickable(By.ClassName("burger-menu"));

        [AllureStep("Click on burger btn")]
        public void ClickBurgerInHeader() => BurgerInHeader.Click();
    }
}
