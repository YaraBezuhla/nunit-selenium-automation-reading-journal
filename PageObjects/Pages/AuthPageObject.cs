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

        private IWebElement LoginField => _driver.FindElement(By.Id("username"));

        [AllureStep("Enter login")]
        public void EnterLogin(string login) => LoginField.SendKeys(login);

        private IWebElement PasswordField => _driver.FindElement(By.Id("password"));

        [AllureStep("Enter password")]
        public void EnterPassword(string password) => PasswordField.SendKeys(password);

        private IWebElement LoginButton => _driver.FindElement(By.ClassName("login-btn"));

        [AllureStep("Click on login button")]
        public void ClickOnLoginButton() => LoginButton.Click();

        [AllureStep("Perform full authorisation")]
        public void PerformFullAuthorization(string login, string password)
        {
            EnterLogin(login);
            EnterPassword(password);
            ClickOnLoginButton();
        }

    }
}
