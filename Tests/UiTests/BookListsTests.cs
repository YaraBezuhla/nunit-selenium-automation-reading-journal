using Allure.NUnit;
using Allure.NUnit.Attributes;
using nunit_selenium_automation_reading_journal.Core;

namespace nunit_selenium_automation_reading_journal.Tests.UiTests
{
    [TestFixture]
    [AllureNUnit]
    [AllureFeature("BookListsTests")]
    public class BookListsTests : BaseTest
    {
        [Test]
        [AllureDescription("Successfully add the book to your wishlist")]
        public void SuccessfullyAddBookToWishList()
        {
            String bookExpected = "Я бачу, вас цікавить пітьма";
            Pages.Header.ClickOnLoginInHeader();
            Pages.AuthPage.PerformFullAuthorization("testlogin4", "testlogin4");
            Pages.BookTitles.OpenBook(bookExpected);
            Pages.BookPage.ClickOnWishListButton();
            Pages.Header.ClickOnBurgerButton();
            Pages.Burger.ClickOnWishList();
            Pages.BookTitles.CheckAvailabilityBook(bookExpected);

        }

        [Test]
        [AllureDescription("Delete book with wishlist")]
        public void DeleteBookWithWishList()
        {
            Pages.Header.ClickOnLoginInHeader();
            Pages.AuthPage.PerformFullAuthorization("testlogin4", "testlogin4");
            Pages.Header.ClickOnBurgerButton();
            Pages.Burger.ClickOnWishList();
            Pages.DeleteButtonWithList.ClickOnDeleteButton();
        }

        [Test]
        [AllureDescription("Successfully add the book to your read list")]
        public void SuccessfullyAddBookToReadList()
        {
            String bookExpected = "Інтернат";
            Pages.Header.ClickOnLoginInHeader();
            Pages.AuthPage.PerformFullAuthorization("testlogin4", "testlogin4");
            Pages.BookTitles.OpenBook(bookExpected);
            Pages.BookPage.ClickOnReadListButton();
            Pages.Header.ClickOnBurgerButton();
            Pages.Burger.ClickOnReadList();
            Pages.BookTitles.CheckAvailabilityBook(bookExpected);

        }

        [Test]
        [AllureDescription("Delete book with readlist")]
        public void DeleteBookWithReadList()
        {
            Pages.Header.ClickOnLoginInHeader();
            Pages.AuthPage.PerformFullAuthorization("testlogin4", "testlogin4");
            Pages.Header.ClickOnBurgerButton();
            Pages.Burger.ClickOnReadList();
            Pages.DeleteButtonWithList.ClickOnDeleteButton();
        }
    }
}
