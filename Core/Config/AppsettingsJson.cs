using nunit_selenium_automation_reading_journal.Core.WaitSettings;

namespace nunit_selenium_automation_reading_journal.Core.Config
{
    public class AppsettingsJson
    {
        public Dictionary<string, string> Urls { get; set; }
        public Dictionary<string, string> Browsers { get; set; }
        public WaitConfig WaitConfig { get; set; } = new WaitConfig();
        public Dictionary<string, string> ConnectionString { get; set; }
        public Dictionary<string, string> DatabaseName { get; set; }
    }
}
