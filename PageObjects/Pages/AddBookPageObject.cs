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

        private IWebElement TitleInput() => _driver.WaitUntilClickable(By.Id("title"));
        private IWebElement AuthorInput() => _driver.WaitUntilClickable(By.Id("author"));
        private IWebElement GenreSelect() => _driver.WaitUntilClickable(By.Id("genre"));
        private IWebElement SaveBtn() => _driver.WaitUntilClickable(By.TagName("button"));

        [AllureStep("Enter the title of book")]
        public void EnterTitle(string title) => TitleInput().SendKeys(title);

        [AllureStep("Enter the author of book")]
        public void EnterAuthor(string author) => AuthorInput().SendKeys(author);

        [AllureStep("Select the genre of book")]
        public void SelectGenre(string genre)
        {
            SelectElement select = new SelectElement(GenreSelect());
            select.SelectByText(genre);
        }

        [AllureStep("Click on save btn")]
        public void ClickOnSaveBtn() => SaveBtn().Click();

    }
}
