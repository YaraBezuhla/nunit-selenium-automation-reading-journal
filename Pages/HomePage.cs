using OpenQA.Selenium;

namespace nunit_selenium_automation_reading_journal.Pages
{
    public class HomePage : BasePage
    {
        public HomePage(IWebDriver driver) : base(driver) { }

        By blockTitles = By.XPath("//h2[@data-testid='popular-block-title']");
        public void AssertBooksTitles(params string[] expectedTitles)
        {
            var elements = driver.FindElements(blockTitles);
            var actualTitles = elements.Select(e => e.Text.Trim()).ToArray();
            Assert.That(actualTitles, Is.EqualTo(expectedTitles));
        }
    }
}
