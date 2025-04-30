using Microsoft.Extensions.Configuration;

namespace nunit_selenium_automation_reading_journal.Core.Config
{
    public class ConfigurationProvider
    {
        public static AppsettingsJson LoadSettings(string sectionName)
        {
            var configuration = new ConfigurationBuilder()
           .SetBasePath(Directory.GetCurrentDirectory())
           .AddJsonFile("appsettings.json", optional: true)
           .AddJsonFile("appsettings.Development.json", optional: true)
           .Build();

            var settings = configuration.GetSection(sectionName).Get<AppsettingsJson>();
            return settings;
        }
    }
}
