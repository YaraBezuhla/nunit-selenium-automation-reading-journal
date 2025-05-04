using Allure.NUnit;
using Allure.NUnit.Attributes;
using nunit_selenium_automation_reading_journal.Core;

namespace nunit_selenium_automation_reading_journal.Tests.UiTests
{
    [TestFixture]
    [AllureNUnit]
    public class BookListsTests : BaseTest
    {
        [Test]
        [AllureDescription("Successfully add the book to your wishlist")]
        public void SuccessfullyAddBookToWishList()
        {
            String bookExpected = "Я бачу, вас цікавить пітьма";
            Pages.HeaderComponent.ClickLoginInHeader();
            Pages.AuthPageObject.FullAuthorization("testlogin4", "testlogin4");
            Pages.BookComponent.OpenBook(bookExpected);
            Pages.BookPageObject.ClickOnWishListBtn();
            Pages.HeaderComponent.ClickBurgerInHeader();
            Pages.BurgerComponent.ClickOnWishList();
            Pages.BookComponent.CheckAvailabilityBook(bookExpected);

        }

        [Test]
        [AllureDescription("Delete book with wishlist")]
        public void DeleteBookWithWishList()
        {
            Pages.HeaderComponent.ClickLoginInHeader();
            Pages.AuthPageObject.FullAuthorization("testlogin4", "testlogin4");
            Pages.HeaderComponent.ClickBurgerInHeader();
            Pages.BurgerComponent.ClickOnWishList();
            Pages.DeleteButtonWithList.ClickOnDeleteBtn();
        }

        [Test]
        [AllureDescription("Successfully add the book to your read list")]
        public void SuccessfullyAddBookToReadList()
        {
            String bookExpected = "Інтернат";
            Pages.HeaderComponent.ClickLoginInHeader();
            Pages.AuthPageObject.FullAuthorization("testlogin4", "testlogin4");
            Pages.BookComponent.OpenBook(bookExpected);
            Pages.BookPageObject.ClickOnReadListBtn();
            Pages.HeaderComponent.ClickBurgerInHeader();
            Pages.BurgerComponent.ClickOnReadList();
            Pages.BookComponent.CheckAvailabilityBook(bookExpected);

        }

        [Test]
        [AllureDescription("Delete book with readlist")]
        public void DeleteBookWithReadList()
        {
            Pages.HeaderComponent.ClickLoginInHeader();
            Pages.AuthPageObject.FullAuthorization("testlogin4", "testlogin4");
            Pages.HeaderComponent.ClickBurgerInHeader();
            Pages.BurgerComponent.ClickOnReadList();
            Pages.DeleteButtonWithList.ClickOnDeleteBtn();
        }
    }
}
