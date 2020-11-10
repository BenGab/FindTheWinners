using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace FindTheWinners
{
    public class TestCaseLoader
    {
        private readonly int numberofTestCases;

        public TestCaseLoader(int numberofTestCases)
        {
            this.numberofTestCases = numberofTestCases;
        }

        public List<TestCase> GenerateTestCases()
        {
            var result = new List<TestCase>();

            for (int i = 1; i <= numberofTestCases; i++)
            {
                string[] testCaseData = Console.ReadLine().Trim().Split(' ');
                List<TestData> testDatas = new List<TestData>();

                for (int j = 0; j < Convert.ToInt32(testCaseData[0]); j++)
                {
                    string[] testData = Console.ReadLine().Trim().Split(' ');
                    testDatas.Add(new TestData(Convert.ToInt32(testData[0]), double.Parse(testData[1], CultureInfo.InvariantCulture)));
                }

                result.Add(new TestCase(i, Convert.ToInt32(testCaseData[0]), Convert.ToInt32(testCaseData[1]), double.Parse(testCaseData[2], CultureInfo.InvariantCulture), testDatas));
            }

            return result;
        }
    }
}
