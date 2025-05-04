using Microsoft.Extensions.DependencyInjection;
using nunit_selenium_automation_reading_journal.PageObjects.Components;
using nunit_selenium_automation_reading_journal.PageObjects.Pages;
using nunit_selenium_automation_reading_journal.Services.Database;
using nunit_selenium_automation_reading_journal.TestData;

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

        private BookComponent _bookTitles;
        public BookComponent BookComponent => _bookTitles ??= _serviceProvider.GetRequiredService<BookComponent>();

        private DataManipulation _dataManipulation;
        public DataManipulation DataManipulation => _dataManipulation ??= _serviceProvider.GetRequiredService<DataManipulation>();

        private GetDataWithMongoDB _getDataWithMongoDB;
        public GetDataWithMongoDB GetDataWithMongoDB => _getDataWithMongoDB ??= _serviceProvider.GetRequiredService<GetDataWithMongoDB>();

        private AddBookPageObject _addBookPageObject;
        public AddBookPageObject AddBookPageObject => _addBookPageObject ??= _serviceProvider.GetRequiredService<AddBookPageObject>();

        private HeaderComponent _header;
        public HeaderComponent HeaderComponent => _header ??= _serviceProvider.GetRequiredService<HeaderComponent>();

        private BurgerComponent _burger;
        public BurgerComponent BurgerComponent => _burger ??= _serviceProvider.GetRequiredService<BurgerComponent>();

        private AuthPageObject _authPage;
        public AuthPageObject AuthPageObject => _authPage ??= _serviceProvider.GetRequiredService<AuthPageObject>(); 

        private BookPageObject _bookPage;
        public BookPageObject BookPageObject => _bookPage ??= _serviceProvider.GetRequiredService<BookPageObject>();

        private DeleteButtonWithList _deleteComponrnt;
        public DeleteButtonWithList DeleteButtonWithList => _deleteComponrnt ??= _serviceProvider.GetRequiredService<DeleteButtonWithList>();

        public static void RegisterPages(IServiceCollection services)
        {
            services.AddScoped<HomePageObject>();
            services.AddScoped<BookComponent>();
            services.AddScoped<DataManipulation>();
            services.AddScoped<GetDataWithMongoDB>();
            services.AddScoped<AddBookPageObject>();
            services.AddScoped<HeaderComponent>();
            services.AddScoped<BurgerComponent>();
            services.AddScoped<AuthPageObject>();
            services.AddScoped<BookPageObject>();
            services.AddScoped<DeleteButtonWithList>();
        }
    }
}
