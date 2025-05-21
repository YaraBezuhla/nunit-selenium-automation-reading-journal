
using Boa.Constrictor.Screenplay;
using Boa.Constrictor.Selenium;
using FluentAssertions;
using nunit_selenium_automation_reading_journal.Core;
using nunit_selenium_automation_reading_journal.ScreenplayPages.Interactions;
using nunit_selenium_automation_reading_journal.ScreenplayPages.Pages;

namespace nunit_selenium_automation_reading_journal.Tests.ScreenplayTests.UiScreenplayTests
{
    public class SearchTests : ScreenplayBaseTest
    {

        [Test]
        public void SuccessfulSearchTest()
        {
            Actor.AskingFor(ValueAttribute.Of(SearchPage.SearchInput)).Should().BeEmpty();
            Actor.AttemptsTo(SearchPageTask.For("Інтернат"));
            Actor.WaitsUntil(Text.Of(SearchPage.BookTitle), IsEqualTo.Value("Інтернат"));

        }
    }
}
