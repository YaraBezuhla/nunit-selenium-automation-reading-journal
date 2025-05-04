using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace nunit_selenium_automation_reading_journal.PageObjects.Pages
{
    public class AuthPageObject
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public AuthPageObject(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement InputLogin => _driver.FindElement(By.Id("username"));
        public IWebElement InputPassword => _driver.FindElement(By.Id("password"));
        public IWebElement LoginBtn => _driver.FindElement(By.ClassName("login-btn"));

        [AllureStep("Enter login")]
        public void InputLoginText(string login) => InputLogin.SendKeys(login);

        [AllureStep("Enter password")]
        public void InputPasswordText(string password) => InputPassword.SendKeys(password);

        [AllureStep("Click on login btn")]
        public void ClickOnLoginBtn() => LoginBtn.Click();

        [AllureStep("Full authorization")]
        public void FullAuthorization(string login, string password)
        {
            InputLoginText(login);
            InputPasswordText(password);
            ClickOnLoginBtn();
        }

    }
}
