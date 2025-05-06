using MongoDB.Driver;
using nunit_selenium_automation_reading_journal.Core.Config;

namespace nunit_selenium_automation_reading_journal.Services.Database
{
    public class MongoDbSingleton
    {
        private static readonly Lazy<MongoDbSingleton> instance = new(() => new MongoDbSingleton());

        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;
        private readonly AppsettingsJson _settings = ConfigurationProvider.LoadSettings("TestSettings");

        private MongoDbSingleton()
        {
            var connectionString = _settings.ConnectionString["Local"];

            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase(_settings.DatabaseName["Local"]);
        }

        public static MongoDbSingleton Instance => instance.Value;
        public IMongoDatabase GetDatabase() => _database;
    }
}
