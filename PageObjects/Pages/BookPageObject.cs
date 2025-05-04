using Allure.NUnit.Attributes;
using nunit_selenium_automation_reading_journal.Core.WaitSettings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace nunit_selenium_automation_reading_journal.PageObjects.Pages
{
    public class BookPageObject
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public BookPageObject(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IWebElement WishListButton => _driver.WaitUntilVisible(By.XPath("//button[@data-test='add-to-wishlist']"));

        [AllureStep("Click on WishList Button")]
        public void ClickOnWishListButton() => WishListButton.Click();

        private IWebElement ReadListButton => _driver.WaitUntilVisible(By.XPath("//button[@data-test='add-to-read']"));

        [AllureStep("Click on ReadList Button")]
        public void ClickOnReadListButton() => ReadListButton.Click();

    }
}
