using nunit_selenium_automation_reading_journal.Utils;

namespace nunit_selenium_automation_reading_journal.Tests
{
    [TestFixture]
    public class ApiTests
    {
        [Test]
        public async Task successfulAddingBookTest ()
        {
           ApiMethods apiMethods = new ApiMethods ();
           await apiMethods.AddBookByApi(0, 201);
        }
    }
}
