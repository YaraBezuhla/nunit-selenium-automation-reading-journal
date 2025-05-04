using Allure.NUnit.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;

namespace nunit_selenium_automation_reading_journal.Services.Database
{
    public class GetDataWithMongoDB
    {
        [AllureStep("Get all books with Database")]
        public async Task<List<string>> GetBookTitlesFromDatabase()
        {
            List<string> titles = new List<string>();
            var database = MongoDbSingleton.Instance.GetDatabase();
            IMongoCollection<BsonDocument> booksCollection = database.GetCollection<BsonDocument>("books");

            var filter = Builders<BsonDocument>.Filter.Exists("title") & Builders<BsonDocument>.Filter.Exists("top");
            var books = await booksCollection.Find(filter).ToListAsync();

            foreach (var book in books)
            {
                string title = book.GetValue("title", "").AsString;
                bool top = book.GetValue("top", false).AsBoolean;

                if(!string.IsNullOrEmpty(title) && top)
                {
                    titles.Add(title);
                }
            }
            return titles;  
        }
    }
}
