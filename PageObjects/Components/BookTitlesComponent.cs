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
                    break ;
                }
            }
            var books = GetBookTitles();
            foreach (var book in books)
            {
                string title = book.Text;
                if(!string.IsNullOrEmpty(title))
                {
                    titles.Add(title);
                }
            }
            return titles;
        }
    }
}
