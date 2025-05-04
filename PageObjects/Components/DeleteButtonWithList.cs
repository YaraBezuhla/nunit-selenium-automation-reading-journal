using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using Allure.NUnit.Attributes;

namespace nunit_selenium_automation_reading_journal.PageObjects.Components
{
    public class DeleteButtonWithList
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public DeleteButtonWithList(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        public IWebElement DeleteBtn => _driver.FindElement(By.ClassName("delete-button"));

        [AllureStep("Click on Delete Btn")]
        public void ClickOnDeleteBtn()
        {
            try
            {
                DeleteBtn.Click();
            }
            catch (Exception)
            {
                throw new Exception("The book is missing from the list");
            }

        }

    }

}
