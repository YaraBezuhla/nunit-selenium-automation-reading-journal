using Allure.NUnit.Attributes;
using nunit_selenium_automation_reading_journal.Core.WaitSettings;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace nunit_selenium_automation_reading_journal.PageObjects.Pages
{
    public class AddBookPageObject
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public AddBookPageObject(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IWebElement TitleField => _driver.WaitUntilClickable(By.Id("title"));

        [AllureStep("Enter the title of book")]
        public void EnterTitle(string title) => TitleField.SendKeys(title);

        private IWebElement AuthorField => _driver.WaitUntilClickable(By.Id("author"));

        [AllureStep("Enter the author of book")]
        public void EnterAuthor(string author) => AuthorField.SendKeys(author);

        private IWebElement GenreSelector => _driver.WaitUntilClickable(By.Id("genre"));

        [AllureStep("Select the genre of book")]
        public void SelectGenre(string genre)
        {
            SelectElement select = new SelectElement(GenreSelector);
            select.SelectByText(genre);
        }

        private IWebElement SaveButton => _driver.WaitUntilClickable(By.TagName("button"));

        [AllureStep("Click on save button")]
        public void ClickOnSaveButton() => SaveButton.Click();

    }
}
