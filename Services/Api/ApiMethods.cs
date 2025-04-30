using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace nunit_selenium_automation_reading_journal.Services.Api
{
    public class ApiMethods
    {
        private static readonly HttpClient _client = new HttpClient { BaseAddress = new Uri("http://localhost:5000") };

        public async Task AddBookByApi(JObject book, int expectedCode)
        {
            var json = JsonConvert.SerializeObject(book, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            var response = await _client.PostAsync("/api/books", content);
            Assert.That((int)response.StatusCode, Is.EqualTo(expectedCode));

        }

        public async Task DeleteBookByApi(List<JObject> books)
        {
            await Task.WhenAll(books.Select(async book =>
            {
                string title = book["title"]?.ToString();
                try
                {
                    var response = await _client.DeleteAsync($"/api/books/title/{title}");
                    if (!response.IsSuccessStatusCode)
                    {
                        Console.WriteLine($"Книга {title} не знайдена. Пропущено.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Помилка при видаленні книги {title}: {ex.Message}");
                }
            }));
        }

    
    }
}
