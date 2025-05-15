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

        private BookTitlesComponent _bookTitles;
        public BookTitlesComponent BookTitles => _bookTitles ??= _serviceProvider.GetRequiredService<BookTitlesComponent>();

        private DataManipulation _dataManipulation;
        public DataManipulation DataManipulation => _dataManipulation ??= _serviceProvider.GetRequiredService<DataManipulation>();

        private GetDataWithMongoDB _getDataWithMongoDB;
        public GetDataWithMongoDB GetDataWithMongoDB => _getDataWithMongoDB ??= _serviceProvider.GetRequiredService<GetDataWithMongoDB>();

        private AddBookPageObject _addBookPageObject;
        public AddBookPageObject AddBook => _addBookPageObject ??= _serviceProvider.GetRequiredService<AddBookPageObject>();

        private HeaderComponent _header;
        public HeaderComponent Header => _header ??= _serviceProvider.GetRequiredService<HeaderComponent>();

        private BurgerComponent _burger;
        public BurgerComponent Burger => _burger ??= _serviceProvider.GetRequiredService<BurgerComponent>();

        private AuthPageObject _authPage;
        public AuthPageObject AuthPage => _authPage ??= _serviceProvider.GetRequiredService<AuthPageObject>(); 

        private BookPageObject _bookPage;
        public BookPageObject BookPage => _bookPage ??= _serviceProvider.GetRequiredService<BookPageObject>();

        private DeleteButtonWithList _deleteComponent;
        public DeleteButtonWithList DeleteButtonWithList => _deleteComponent ??= _serviceProvider.GetRequiredService<DeleteButtonWithList>();

        public static void RegisterPages(IServiceCollection services)
        {
            services.AddSingleton<HomePageObject>();
            services.AddSingleton<BookTitlesComponent>();
            services.AddSingleton<DataManipulation>();
            services.AddSingleton<GetDataWithMongoDB>();
            services.AddSingleton<AddBookPageObject>();
            services.AddSingleton<HeaderComponent>();
            services.AddSingleton<BurgerComponent>();
            services.AddSingleton<AuthPageObject>();
            services.AddSingleton<BookPageObject>();
            services.AddSingleton<DeleteButtonWithList>();
        }
    }
}
