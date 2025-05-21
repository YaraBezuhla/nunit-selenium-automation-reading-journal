
using Boa.Constrictor.Screenplay;
using nunit_selenium_automation_reading_journal.ScreenplayPages.Api.Models;

namespace nunit_selenium_automation_reading_journal.ScreenplayPages.Api.Responses
{
    public class BookCreateModel
    {
        public string _id { get; set; }            
        public string title { get; set; }
        public string genre { get; set; }
        public string coverImage { get; set; }
        public bool top { get; set; }
        public string author { get; set; }
    }
}
