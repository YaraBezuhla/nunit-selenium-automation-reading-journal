using Allure.NUnit;
using Allure.NUnit.Attributes;
using nunit_selenium_automation_reading_journal.Core;

namespace nunit_selenium_automation_reading_journal.Tests.UiTests
{
    [TestFixture]
    [AllureNUnit]
    public class HomePageTests : BaseTest
    {

        [Test]
        [AllureDescription("Checking the titles on the home page")]
        public void AssertBlocksTitles()
        {
            Pages.HomePage.AssertBooksTitles("Найпопулярнішікниги", "Українські автори");
        }
    }
}
