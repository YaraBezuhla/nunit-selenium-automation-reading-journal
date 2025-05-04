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

        private IWebElement AddBookPage => _driver.FindElement(By.XPath("//a[@data-test='add-book-link']"));

        [AllureStep("Go to Add Book page")]
        public void GoToAddBookPage() => AddBookPage.Click();

        private IWebElement LoginInHeader => _driver.FindElement(By.ClassName("auth-btn"));

        [AllureStep("Click on login button")]
        public void ClickOnLoginInHeader() => LoginInHeader.Click();

        private IWebElement BurgerButton => _driver.WaitUntilClickable(By.ClassName("burger-menu"));

        [AllureStep("Click on burger button")]
        public void ClickOnBurgerButton() => BurgerButton.Click();
    }
}
