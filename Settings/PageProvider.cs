using Microsoft.Extensions.DependencyInjection;
using nunit_selenium_automation_reading_journal.Pages;

namespace nunit_selenium_automation_reading_journal.Settings
{
    public class PageProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public PageProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public HomePageObject HomePage => new Lazy<HomePageObject>(() => _serviceProvider.GetRequiredService<HomePageObject>()).Value;
        public SearchPageObject SearchPage => new Lazy<SearchPageObject>(() => _serviceProvider.GetRequiredService<SearchPageObject>()).Value;

        public static void RegisterPages(IServiceCollection services)
        {
            services.AddTransient<HomePageObject>();
            services.AddTransient<SearchPageObject>();
        }
    }
}
