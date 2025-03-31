
using Allure.NUnit;
using Allure.NUnit.Attributes;

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
            Pages.HomePage.AssertBooksTitles("Найпопулярнішікниги", "Українські автори");
        }
    }
}
