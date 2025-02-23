using MongoDB.Driver;


namespace nunit_selenium_automation_reading_journal.Database
{
    public class MongoDbSingleton
    {
        private static readonly Lazy<MongoDbSingleton> instance = 
            new(() => new MongoDbSingleton());

        private readonly IMongoClient _client;
        private readonly IMongoDatabase _database;

        private MongoDbSingleton()
        {
            var connectionString = Environment.GetEnvironmentVariable("MONGO_DB_CONNECTION")
                ?? "mongodb://localhost:27017";

            _client = new MongoClient(connectionString);
            _database = _client.GetDatabase("automationreadingjournal");
        }

        public static MongoDbSingleton Instance => instance.Value;
        public IMongoDatabase GetDatabase() => _database;   
    }
}
