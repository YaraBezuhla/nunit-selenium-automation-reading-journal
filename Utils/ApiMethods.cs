using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace nunit_selenium_automation_reading_journal.Utils
{
    public class ApiMethods
    {
        private static readonly string BOOKS_JSON_FILE = "C:/Users/Ярослава/Projects/nunit-selenium-automation-reading-journal/TestData/books.json";
        private static readonly HttpClient client = new HttpClient { BaseAddress = new Uri("http://localhost:5000") };

public async Task AddBookByApi(int bookIndex, int codeResponse)
        {
            if (!File.Exists(BOOKS_JSON_FILE))
            {
                throw new FileNotFoundException("Файл BOOKS_JSON_FILE не знайдено");
            }

            string jsonContent = await File.ReadAllTextAsync(BOOKS_JSON_FILE); // Асинхронне читання JSON-файлу
            JArray jArray = JArray.Parse(jsonContent); // Парсимо JSON у масив

            if (bookIndex < 0 || bookIndex >= jArray.Count)
            {
                throw new IndexOutOfRangeException("Неправильний індекс книги.");
            }

            JObject selectedBook = (JObject)jArray[bookIndex];
            var json = JsonConvert.SerializeObject(selectedBook, Formatting.Indented); // Серіалізація у JSON-рядок

            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var responce = await client.PostAsync("/api/books", content);
            Assert.That((int)responce.StatusCode, Is.EqualTo(codeResponse));

        }

        public async Task DeleteBookByApi()
        {
            if(!File.Exists(BOOKS_JSON_FILE))
            {
                throw new FileNotFoundException("Файл BOOKS_JSON_FILE не знайдено");

            }
            
            string jsonContent = await File.ReadAllTextAsync(BOOKS_JSON_FILE);
            List<Dictionary<string, object>> books = JsonConvert.DeserializeObject<List<Dictionary<string, object>>>(jsonContent);


            await Task.WhenAll(books.Select(async book =>
            {
                string title = book["title"].ToString();
                try
                {
                    var responce = await client.DeleteAsync($"/api/books/title/{title}");

                    if (!responce.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Книга {title} не знайдена в базі даних. Пропущено.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.ToString());
                }
            }));
            
        }
    }
}
