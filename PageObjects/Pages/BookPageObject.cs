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

        public IWebElement WishListBtn => _driver.WaitUntilVisible(By.XPath("//button[@data-test='add-to-wishlist']"));
        public IWebElement ReadListBtn => _driver.WaitUntilVisible(By.XPath("//button[@data-test='add-to-read']"));

        [AllureStep("Click on WishList btn")]
        public void ClickOnWishListBtn() => WishListBtn.Click();

        [AllureStep("Click on ReadList btn")]
        public void ClickOnReadListBtn() => ReadListBtn.Click();

    }
}
