

using RestSharp;

namespace nunit_selenium_automation_reading_journal.ScreenplayPages.Api
{
    public static class ApiMethodsByScreenplay
    {
        public static RestRequest GetBookInfo() =>
            new RestRequest("api/books/680a1b593afef23a0172d6e0", Method.Get);

        public static RestRequest CreateBook() =>
            new RestRequest("api/books", Method.Post);
    }
}
