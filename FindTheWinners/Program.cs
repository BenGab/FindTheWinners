using System;
using System.Collections.Generic;

namespace FindTheWinners
{
    class Program
    {
        static void Main(string[] args)
        {
            List<TestData> testDatas1 = new List<TestData>()
            {
                new TestData(0, 1.00)
            };
            TestCase testcase1 = new TestCase(1,1, 1, 1, testDatas1);
            testcase1.Run();

            //0 0.10
            //0 0.89
            //1 0.99
            List<TestData> testDatas2 = new List<TestData>()
            {
                new TestData(0, 0.10),
                new TestData(0, 0.89),
                new TestData(1, 0.99)
            };

            TestCase testCase2 = new TestCase(2, 3, 2, 1, testDatas2);
            testCase2.Run();

//            1 320.80
//0 69.20
//1 564.50
            List<TestData> testDatas3 = new List<TestData>()
            {
                new TestData(0, 320.80),
                new TestData(0, 69.20),
                new TestData(1, 564.50)
            };

            TestCase testCase3 = new TestCase(3, 3, 2, 10, testDatas3);
            testCase3.Run();

        }
    }
}
