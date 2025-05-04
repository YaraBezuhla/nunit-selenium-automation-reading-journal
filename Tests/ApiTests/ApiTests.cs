using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using nunit_selenium_automation_reading_journal.Services.Api;
using nunit_selenium_automation_reading_journal.TestData.Providers;

namespace nunit_selenium_automation_reading_journal.Tests.ApiTests
{
    [TestFixture]
    [AllureNUnit]
    public class ApiTests
    {
        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        public async Task SuccessfulAddingBookTest()
        {
            ApiMethods apiMethods = new ApiMethods();

            var book = BookDataProvider.GetBookByIndex(0);
            await apiMethods.AddBookByApi(book, 201);
        }

    }
}
