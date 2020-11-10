using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FindClusters
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

        public List<ConnectedComponents> GenerateTestCases()
        {
            var result = new List<ConnectedComponents>();
            int startIndex = 1;

            for (int i = 1; i <= numberofTestCases; i++)
            {
                string[] testCaseData = content[startIndex].Trim().Split(' ');
                int col = int.Parse(testCaseData[0]);
                int row = int.Parse(testCaseData[1]);
                int[,] testData = new int[row,col];
                ++startIndex;

                for (int crow = 0; crow < row; crow++)
                {
                    string[] rowValues = content[startIndex].Trim().Split(' ');
                    for (int ccol = 0; ccol < col; ccol++)
                    {
                        testData[crow, ccol] = int.Parse(rowValues[ccol]);
                    }
                    ++startIndex;
                }

                result.Add(new ConnectedComponents(col, row, testData));
            }

            return result;
        }
    }
}
