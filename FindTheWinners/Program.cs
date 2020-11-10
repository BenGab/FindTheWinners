using System;
using System.Collections.Generic;
using System.IO;

namespace FindTheWinners
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCaseLoader loader = new TestCaseLoader("input.txt");
            using (StreamWriter writer = new StreamWriter("output.txt"))
            {
                loader.GenerateTestCases().ForEach(x => x.Run(writer));
            }
        }
    }
}
