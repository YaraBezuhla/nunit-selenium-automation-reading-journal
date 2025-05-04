using Allure.NUnit.Attributes;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Text;

namespace nunit_selenium_automation_reading_journal.Services.Api
{
    public class ApiMethods
    {
        private static readonly HttpClient _client = new HttpClient { BaseAddress = new Uri("http://localhost:5000") };

        [AllureStep("Add a book by API")]
        public async Task AddBookByApi(JObject book, int expectedCode)
        {
            var json = JsonConvert.SerializeObject(book, Formatting.Indented);
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var response = await _client.PostAsync("/api/books", content);
                Assert.That((int)response.StatusCode, Is.EqualTo(expectedCode));
            }

            catch (HttpRequestException ex)
            {
                Assert.Fail($"HTTP request error: {ex.Message}");
            }

        }

        [AllureStep("Delete a book by API")]
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
                        Console.WriteLine($"The book {title} was not found. Skipped.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error when deleting a book {title}: {ex.Message}");
                }
            }));
        }
    }
}
