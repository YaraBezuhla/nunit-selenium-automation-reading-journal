using nunit_selenium_automation_reading_journal.Settings.WaitSettings;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace nunit_selenium_automation_reading_journal.Settings
{
    public class AppsettingsJson
    {
        public Dictionary<string, string> Urls { get; set; }
        public Dictionary<string, string> Browsers { get; set; }
        public WaitConfig WaitConfig { get; set; } = new WaitConfig();
    }
}
