using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;

namespace FindTheWinners
{
    public class TestCase
    {
        private readonly int testcaseId;
        private readonly int numberOfWinnings;
        private readonly int numberOfPlayers;
        private readonly double winLimit;
        private readonly ICollection<TestData> testDatas;

        public TestCase(int testcaseId, int numberOfWinnings, int numberOfPlayers, double winLimit, ICollection<TestData> testDatas)
        {
            this.testcaseId = testcaseId;
            this.numberOfWinnings = numberOfWinnings;
            this.numberOfPlayers = numberOfPlayers;
            this.winLimit = winLimit;
            this.testDatas = testDatas;
        }

        public void Run(StreamWriter writer)
        {
            //Presentation form DS&A based solution
            //Dictionary<int, decimal> sumOfWinnings = new Dictionary<int, decimal>();

            //foreach(var item in testDatas)
            //{
            //    if(sumOfWinnings.ContainsKey(item.PlayerId))
            //    {
            //        sumOfWinnings[item.PlayerId] += item.WinAmount;
            //    }
            //    else
            //    {
            //        sumOfWinnings.Add(item.PlayerId, item.WinAmount);
            //    }
            //}

            //LINQ based solution
            var winnersum = from data in testDatas.AsEnumerable()
                            group data by data.PlayerId into grp
                            select new
                            {
                                PlayerId = grp.Key,
                                Amount = grp.Sum(x => x.WinAmount)
                            };

            var achievement = winnersum.Where(x => x.Amount >= winLimit).Select(x => x.PlayerId).ToList();
            var result = achievement.Count > 0 ? String.Join(' ', achievement) : "NO";
            Console.WriteLine($"Case #{testcaseId}: {result}");
            writer.WriteLine($"Case #{testcaseId}: {result}");
        }
    }
}
