
using Boa.Constrictor.Selenium;
using OpenQA.Selenium;
using static Boa.Constrictor.Selenium.WebLocator;

namespace nunit_selenium_automation_reading_journal.ScreenplayPages.Pages
{
    public static class SearchPage
    {
        public const string Url = "http://localhost:8080/search";

        public static IWebLocator SearchInput => L(
            "Books Search Input",
            By.ClassName("search-input"));

        public static IWebLocator BookTitle => L(
            "Book Title",
            By.XPath("//h3[@data-test='search-book-title']"));
    }
}
