using Microsoft.Extensions.DependencyInjection;
using nunit_selenium_automation_reading_journal.PageObjects.Components;
using nunit_selenium_automation_reading_journal.PageObjects.Pages;
using nunit_selenium_automation_reading_journal.Services.Database;

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

        private BookTitlesComponent _bookTitles;
        public BookTitlesComponent BookTitles => _bookTitles ??= _serviceProvider.GetRequiredService<BookTitlesComponent>();

        private DataManipulation _dataManipulation;
        public DataManipulation DataManipulation => _dataManipulation ??= _serviceProvider.GetRequiredService<DataManipulation>();

        private GetDataWithMongoDB _getDataWithMongoDB;
        public GetDataWithMongoDB GetDataWithMongoDB => _getDataWithMongoDB ??= _serviceProvider.GetRequiredService<GetDataWithMongoDB>();

        public static void RegisterPages(IServiceCollection services)
        {
            services.AddScoped<HomePageObject>();
            services.AddScoped<SearchPageObject>();
            services.AddScoped<BookTitlesComponent>();
            services.AddScoped<DataManipulation>();
            services.AddScoped<GetDataWithMongoDB>();
        }
    }
}
