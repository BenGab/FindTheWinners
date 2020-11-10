using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Text;

namespace FindTheWinners
{
    public class TestCaseLoader
    {
        private readonly int numberofTestCases;
        private readonly string[] content;
        public TestCaseLoader(string input)
        {
            content = File.ReadAllLines(input);
            this.numberofTestCases = int.Parse(content[0]);
        }

        public List<TestCase> GenerateTestCases()
        {
            var result = new List<TestCase>();
            int startIndex = 1;

            for (int i = 1; i <= numberofTestCases; i++)
            {
                string[] testCaseData = content[startIndex].Trim().Split(' ');
                List<TestData> testDatas = new List<TestData>();
                ++startIndex;

                for (int j = 0; j < Convert.ToInt32(testCaseData[0]); j++)
                {
                    string[] testData = content[startIndex].Trim().Split(' ');
                    testDatas.Add(new TestData(Convert.ToInt32(testData[0]), double.Parse(testData[1], CultureInfo.InvariantCulture)));
                    ++startIndex;
                }

                result.Add(new TestCase(i, Convert.ToInt32(testCaseData[0]), Convert.ToInt32(testCaseData[1]), double.Parse(testCaseData[2], CultureInfo.InvariantCulture), testDatas));
            }

            return result;
        }
    }
}
