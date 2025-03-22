using OpenQA.Selenium;

namespace nunit_selenium_automation_reading_journal.Pages
{
    public class HomePageObject 
    {
        private readonly IWebDriver _driver;

        public HomePageObject(IWebDriver driver)
        {
            _driver = driver;
        }

        private IReadOnlyCollection<IWebElement> GetBlockTitles() => _driver.FindElements(By.XPath("//h2[@data-testid='popular-block-title']"));

        public void AssertBooksTitles(params string[] expectedTitles)
        {
            var blockTitles = GetBlockTitles();

            var actualTitles = blockTitles.Select(e => e.Text.Trim()).ToArray();
            Assert.That(actualTitles, Is.EqualTo(expectedTitles));
        }
    }
}
