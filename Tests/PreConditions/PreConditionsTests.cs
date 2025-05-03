using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using nunit_selenium_automation_reading_journal.Services.Api;
using nunit_selenium_automation_reading_journal.TestData.Providers;

namespace nunit_selenium_automation_reading_journal.TestData.PreConditions
{
    [TestFixture]
    [AllureNUnit]
    public class PreConditionsTests
    {

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        public async Task DeleteBook()
        {
            var book = BookDataProvider.GetBooks();
            ApiMethods apiMethods = new ApiMethods();
            await apiMethods.DeleteBookByApi(book);
        }
    }
}
