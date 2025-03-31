using Microsoft.Extensions.Configuration;

namespace nunit_selenium_automation_reading_journal.Settings.ConfigurationSettings
{
    public class ConfigurationProvider
    {
        public static AppsettingsJson LoadSettings()
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json")
           .Build();

            var settings = configuration.GetSection("TestSettings").Get<AppsettingsJson>();
            return settings;
        }
    }
}
