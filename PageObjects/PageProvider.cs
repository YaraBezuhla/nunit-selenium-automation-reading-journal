using Microsoft.Extensions.DependencyInjection;
using nunit_selenium_automation_reading_journal.PageObjects.Pages;

namespace nunit_selenium_automation_reading_journal.PageObjects
{
    public class PageProvider
    {
        private readonly IServiceProvider _serviceProvider;

        public PageProvider(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        private HomePageObject _homePage;
        public HomePageObject HomePage => _homePage ??= _serviceProvider.GetRequiredService<HomePageObject>();

        private SearchPageObject _searchPage;
        public SearchPageObject SearchPage => _searchPage ??= _serviceProvider.GetRequiredService<SearchPageObject>();

        public static void RegisterPages(IServiceCollection services)
        {
            services.AddScoped<HomePageObject>();
            services.AddScoped<SearchPageObject>();
        }
    }
}
