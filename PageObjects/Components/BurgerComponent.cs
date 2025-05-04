using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Allure.NUnit.Attributes;

namespace nunit_selenium_automation_reading_journal.PageObjects.Components
{
    public class BurgerComponent
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public BurgerComponent(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement WishList => _driver.FindElement(By.XPath("//a[@data-test='wishlist-link']"));
        public IWebElement ReadList => _driver.FindElement(By.XPath("//a[@data-test='read-books-link']"));

        [AllureStep("Click on WishList")]
        public void ClickOnWishList() => WishList.Click();

        [AllureStep("Click on ReadList")]
        public void ClickOnReadList() => ReadList.Click();

    }
}
