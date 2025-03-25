using Allure.Net.Commons;
using Allure.NUnit;
using Allure.NUnit.Attributes;
using nunit_selenium_automation_reading_journal.Utils;

namespace nunit_selenium_automation_reading_journal.Tests
{
    [TestFixture]
    [AllureNUnit]
    public class ApiTests
    {
        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        public async Task SuccessfulAddingBookTest ()
        {
           ApiMethods apiMethods = new ApiMethods ();
           await apiMethods.AddBookByApi(0, 201);
        }

        [Test]
        [AllureSeverity(SeverityLevel.critical)]
        public async Task DeleteBook()
        {
            ApiMethods apiMethods = new ApiMethods();
            await apiMethods.DeleteBookByApi();
        }
    }
}
