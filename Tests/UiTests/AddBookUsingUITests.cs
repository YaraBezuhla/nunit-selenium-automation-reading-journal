using Allure.NUnit;
using Allure.NUnit.Attributes;
using nunit_selenium_automation_reading_journal.Core;

namespace nunit_selenium_automation_reading_journal.Tests.UiTests
{
    [TestFixture]
    [AllureNUnit]
    public class AddBookUsingUITests : BaseTest
    {
        [Test]
        [AllureDescription("Successfully adding books via the form on the website")]
        [TestCase("Дзвінка", "Ніна Кур'ята", "Роман")]
        [TestCase("Танець Недоумка", "Ілларіон Павлюк", "Фентезі")]
        public void AddBookTest(string title, string author, string genre)
        {
            Pages.HeaderComponent.GoToAddBook();
            Pages.AddBookPageObject.EnterTitle(title);
            Pages.AddBookPageObject.EnterAuthor(author);
            Pages.AddBookPageObject.SelectGenre(genre);
            Pages.AddBookPageObject.ClickOnSaveBtn();
        }
    }
}
