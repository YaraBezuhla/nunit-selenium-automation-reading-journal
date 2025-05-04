using Newtonsoft.Json.Linq;

namespace nunit_selenium_automation_reading_journal.TestData.Providers
{
    public static class BookDataProvider
    {

        public static List<JObject> GetBooks(string relativePath = "TestData/Data/books.json")
        {
            string fullPath = Path.Combine(AppContext.BaseDirectory, relativePath);

            if (!File.Exists(fullPath))
                throw new FileNotFoundException($"File not found: {fullPath}");

            var json = File.ReadAllText(fullPath);
            var jArray = JArray.Parse(json);

            return jArray.Select(token => (JObject)token).ToList();
        }

        public static JObject GetBookByIndex(int index, string path = "TestData/Data/books.json")
        {
            var books = GetBooks(path);
            if (index < 0 || index >= books.Count)
                throw new IndexOutOfRangeException("Incorrect book index.");

            return books[index];
        }
    }
}
