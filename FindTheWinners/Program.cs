using System;
using System.Collections.Generic;

namespace FindTheWinners
{
    class Program
    {
        static void Main(string[] args)
        {
            TestCaseLoader loader = new TestCaseLoader(Convert.ToInt32(Console.ReadLine().Trim()));
            loader.GenerateTestCases().ForEach(x=> x.Run());
        }
    }
}
