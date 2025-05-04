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
            Pages.HomePage.AssertBooksTitles("Найпопулярніші книги", "Українські автори");
        }

        [Test]
        [AllureDescription("Comparison of books in the database and those displayed on the website by title")]
        public void AssertBooks()
        {
            List<string> dbTitles = Pages.GetDataWithMongoDB.GetBookTitlesFromDatabase();
            List<string> webTitles = Pages.BookComponent.GetBookTitlesOnWebsite();
            Pages.DataManipulation.CompareTwoLists (dbTitles, webTitles);
        }
    }
}
