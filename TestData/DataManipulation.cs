using System.Text;


namespace nunit_selenium_automation_reading_journal.TestData
{
    public class DataManipulation
    {
        public void CompareTwoLists(List<string> listFirst, List<string> listSecond)
        {
            // dbData.Sort();  //webData.Sort();

            if (!listFirst.ToHashSet().SetEquals(listSecond))
            {
                var webDataSet = new HashSet<string>(listSecond);
                var missingOnWebsite = listFirst.Where(title => !webDataSet.Contains(title)).ToList();

                var dbDataSet = new HashSet<string>(listFirst);
                var missingOnDB = listSecond.Where(title => !dbDataSet.Contains(title)).ToList();

                StringBuilder errorMessage = new StringBuilder("The data does not match:").Append("\n");
                if (missingOnWebsite.Any())
                {
                    errorMessage.AppendLine($"The data is available in the database but not on the website: {string.Join(", ", missingOnWebsite)}");
                }
                if (missingOnDB.Any())
                {
                    errorMessage.AppendLine($"Data on the website but not in the database: {string.Join(", ", missingOnDB)}");
                }

                Assert.Fail(errorMessage.ToString());
            }
        }
    }
}
