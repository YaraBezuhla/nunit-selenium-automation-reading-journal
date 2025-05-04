using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using nunit_selenium_automation_reading_journal.Core.WaitSettings;
using Allure.NUnit.Attributes;

namespace nunit_selenium_automation_reading_journal.PageObjects.Components
{
    public class BookTitlesComponent
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public BookTitlesComponent(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IList<IWebElement> GetBookTitles => _driver.WaitUntilAllVisible(By.ClassName("book-title"));

        private IWebElement LoadMoreBooksButton => _driver.FindElement(By.XPath("//div[@data-test='top-books']//button[@data-test='load-more-button']"));

        [AllureStep("Get all book titles from the site")]
        public List<string> GetAllBookTitlesFromWebsite()
        {
            List<string> titles = new List<string>();

            while (true)
            {
                try
                {
                    if (LoadMoreBooksButton.Displayed)
                    {
                        LoadMoreBooksButton.Click();
                    }
                    else
                    {
                        break;
                    }
                }
                catch (NoSuchElementException)
                {
                    break;
                }
            }
            var books = GetBookTitles;
            foreach (var book in books)
            {
                string title = book.Text;
                if (!string.IsNullOrEmpty(title))
                {
                    titles.Add(title);
                }
            }
            return titles;
        }

        [AllureStep("Open the book by title")]
        public void OpenBook(string bookExpected)
        {
            foreach (var name in GetBookTitles)
            {
                string book = name.Text;
                if (book.Equals(bookExpected))
                {
                    name.Click();
                    break;
                }
            }
        }

        [AllureStep("Check the availability of a book by title")]
        public void CheckAvailabilityBook(string bookExpected)
        {
            bool found = false;
            foreach (var name in GetBookTitles)
            {
                string book = name.Text;
                if (book.Equals(bookExpected))
                {
                    found = true;
                    break;
                }
            }
            Assert.That(found, Is.True, $"Expected to find the book '{bookExpected}', but it was not found.");
        }
    }
}
