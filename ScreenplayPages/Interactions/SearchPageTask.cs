using Boa.Constrictor.Screenplay;
using Boa.Constrictor.Selenium;
using nunit_selenium_automation_reading_journal.ScreenplayPages.Pages;

namespace nunit_selenium_automation_reading_journal.ScreenplayPages.Interactions
{
    public class SearchPageTask : ITask
    {
        public string Phrase { get; }

        private SearchPageTask(string phrase) => Phrase = phrase;

        public static SearchPageTask For(string phrase) => new SearchPageTask(phrase);

        public void PerformAs(IActor actor)
        {
            actor.AttemptsTo(SendKeys.To(SearchPage.SearchInput, Phrase));
        }
    }
}
