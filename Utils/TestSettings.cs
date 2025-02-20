using Newtonsoft.Json.Linq;

namespace nunit_selenium_automation_reading_journal.Utils
{
    public class TestSettings
    {
        public static string GetBrowser()
        {
            var json = File.ReadAllText("Configs/appsettings.json");
            var jsonObj = JObject.Parse(json);
            return jsonObj["Browser"]?.ToString();
        }
    }
}
