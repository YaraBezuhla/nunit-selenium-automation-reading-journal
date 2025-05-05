using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using nunit_selenium_automation_reading_journal.Services.Api;
using nunit_selenium_automation_reading_journal.TestData.Providers;

namespace nunit_selenium_automation_reading_journal.TestData.PreConditions
{
    [TestFixture]
    [AllureNUnit]
    [AllureFeature("PreConditionsTests")]
    [Category("Preconditions")]
    public class PreConditionsTests
    {

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        public async Task DeleteBook()
        {
            ApiMethods apiMethods = new ApiMethods();

            var book = BookDataProvider.GetBooks();
            await apiMethods.DeleteBookByApi(book);
        }
    }
}
