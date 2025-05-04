using OpenQA.Selenium.Support.UI;
using OpenQA.Selenium;
using nunit_selenium_automation_reading_journal.Core.WaitSettings;
using Allure.NUnit.Attributes;
using System.Reflection;

namespace nunit_selenium_automation_reading_journal.PageObjects.Components
{
    public class BookComponent
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public BookComponent(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        private IList<IWebElement> GetBookTitles() => _driver.WaitUntilAllVisible(By.ClassName("book-title"));

        private IWebElement LoadMoreButtonBooksBlock => _driver.FindElement(By.XPath("//div[@data-test='top-books']//button[@data-test='load-more-button']"));

        [AllureStep("Get all books with website")]
        public List<string> GetBookTitlesOnWebsite()
        {
            List<string> titles = new List<string>();

            while (true)
            {
                try
                {
                    if (LoadMoreButtonBooksBlock.Displayed)
                    {
                        LoadMoreButtonBooksBlock.Click();
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
            var books = GetBookTitles();
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
            foreach (var name in GetBookTitles())
            {
                string book = name.Text;
                if (book.Equals(bookExpected))
                {
                    name.Click();
                    break;
                }
            }
        }

        [AllureStep("Check the {1} of the book '{0}'")]
        public void CheckAvailabilityBook(string bookExpected)
        {
            bool found = false;
            foreach (var name in GetBookTitles())
            {
                string book = name.Text;
                if (book.Equals(bookExpected))
                {
                    found = true;
                    break;
                }
                Assert.That(found = true, $"Expected to find the book '{bookExpected}', but it was not found.");
            }
        }
    }
}
