
using nunit_selenium_automation_reading_journal.Pages;

namespace nunit_selenium_automation_reading_journal.Tests
{
    [TestFixture]
    public class HomePageTests : LaunchSettings
    {
       

        [Test]
        public void AssertBlocksTitles()
        {
            HomePageObject homePage = new HomePageObject(driver);
            homePage.AssertBooksTitles("Найпопулярніші книги", "Українські автори");

        }
    }
}
