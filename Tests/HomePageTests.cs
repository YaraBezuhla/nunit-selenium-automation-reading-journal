
using Allure.NUnit;
using Allure.NUnit.Attributes;
using nunit_selenium_automation_reading_journal.Pages;

namespace nunit_selenium_automation_reading_journal.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class HomePageTests : LaunchSettings
    {
       

        [Test]
        [AllureDescription("Перевірка тайтлів на головній сторінці")]
        public void AssertBlocksTitles()
        {
            HomePageObject homePage = new HomePageObject(driver, wait);
            homePage.AssertBooksTitles("Найпопулярнішікниги", "Українські автори");

        }
    }
}
