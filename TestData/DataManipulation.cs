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
                var listSecondDataSet = new HashSet<string>(listSecond);
                var missingOnSecondList = listFirst.Where(title => !listSecondDataSet.Contains(title)).ToList();

                var listFirstDataSet = new HashSet<string>(listFirst);
                var missingOnFirstList = listSecond.Where(title => !listFirstDataSet.Contains(title)).ToList();

                StringBuilder errorMessage = new StringBuilder("The data does not match:").Append("\n");
                if (missingOnSecondList.Any())
                {
                    errorMessage.AppendLine($"The data is available in the first list but not on the second list: {string.Join(", ", missingOnSecondList)}");
                }
                if (missingOnFirstList.Any())
                {
                    errorMessage.AppendLine($"Data on the second list but not in the first list: {string.Join(", ", missingOnFirstList)}");
                }

                Assert.Fail(errorMessage.ToString());
            }
        }
    }
}
