using Allure.NUnit.Attributes;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace nunit_selenium_automation_reading_journal.Pages
{
    public class HomePageObject 
    {
        private readonly IWebDriver _driver;
        private readonly WebDriverWait _wait;

        public HomePageObject(IWebDriver driver, WebDriverWait wait)
        {
            _driver = driver;
            _wait = wait;
        }

        [AllureStep("Отримати всі тайтли на головній сторінці")]
        private IReadOnlyCollection<IWebElement> GetBlockTitles() => _driver.FindElements(By.XPath("//h2[@data-testid='popular-block-title']"));

        [AllureStep("Перевірити тайтли на головній сторінці")]
        public void AssertBooksTitles(params string[] expectedTitles)
        {
            var blockTitles = _wait.Until(d => GetBlockTitles());

            var actualTitles = blockTitles.Select(e => e.Text.Trim()).ToArray();
            Assert.That(actualTitles, Is.EqualTo(expectedTitles), "Назви тайтлів не співпадають");
        }
    }
}
