using Boa.Constrictor.Screenplay;
using Boa.Constrictor.Selenium;
using nunit_selenium_automation_reading_journal.ScreenplayPages.Pages;
using OpenQA.Selenium.Chrome;

namespace nunit_selenium_automation_reading_journal.Core
{
    public class ScreenplayBaseTest
    {
        protected IActor Actor;

        [SetUp]
        public void SetUp()
        {
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
            ChromeDriver driver = new ChromeDriver(options);

            Actor = new Actor("Person", logger: new ConsoleLogger());
            Actor.Can(BrowseTheWeb.With(new ChromeDriver()));

            Actor.AttemptsTo(Navigate.ToUrl(SearchPage.Url));
        }

        [TearDown]
        public void TearDown()
        {
            Actor.AttemptsTo(QuitWebDriver.ForBrowser());
        }
    }
}
