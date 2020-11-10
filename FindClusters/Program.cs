using System;
using System.ComponentModel;
using System.IO;

namespace FindClusters
{
    class Program
    {
        static void Main(string[] args)
        {

            TestCaseLoader loader = new TestCaseLoader("input.txt");
            var testcases = loader.GenerateTestCases();

            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                int i = 0;
                foreach (var item in testcases)
                {
                    var result = item.Do();
                    Console.WriteLine($"Case #{++i}: {result}");
                    writer.WriteLine($"Case #{++i}: {result}");
                }
            }
        }
    }
}
