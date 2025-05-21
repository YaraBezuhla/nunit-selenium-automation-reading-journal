
using Boa.Constrictor.RestSharp;
using Boa.Constrictor.Screenplay;
using FluentAssertions;
using nunit_selenium_automation_reading_journal.ScreenplayPages.Api;
using nunit_selenium_automation_reading_journal.ScreenplayPages.Api.Models;
using nunit_selenium_automation_reading_journal.ScreenplayPages.Api.Responses;
using RestSharp;

namespace nunit_selenium_automation_reading_journal.Tests.ScreenplayTests.ApiScreenplayTests
{
    public class AddBookViaApiByScreenplay
    {
        private IActor Actor;

        [SetUp]
        public void SetUp()
        {
            Actor = new Actor("ApiPerson", logger: new ConsoleLogger());
            Actor.Can(CallRestApi.Using(new RestClient("http://localhost:5000/")));
        }

        [Test]
        public void GetBookStatus()
        {
            var request = ApiMethodsByScreenplay.GetBookInfo();
            var responce = Actor.Calls(Rest.Request(request));
            responce.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);

        }

        [Test]
        public void GetBookContent()
        {
            var request = ApiMethodsByScreenplay.GetBookInfo();
            var response = Actor.Calls(Rest.Request<BookResponseModel>(request));
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.OK);
            response.Data.title.Should().Be("Я бачу, вас цікавить пітьма");
            response.Data._id.Should().NotBeNullOrEmpty();
        }

        [Test]
        public void CreateBook()
        {
            var newBook = new BookCreateModel
            {
                title = "Дзвінка",
                coverImage = "",
                top = true,
                genre = "Роман",
                author = "Ніна Кур’ята"
            };

            var request = ApiMethodsByScreenplay.CreateBook();
            request.AddJsonBody(newBook);

            var response = Actor.Calls(Rest.Request<BookCreateModel>(request));
            response.StatusCode.Should().Be(System.Net.HttpStatusCode.Created);
            response.Data.title.Should().Be("Дзвінка");

        }
    }
}
