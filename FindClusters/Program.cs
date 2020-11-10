using System;

namespace FindClusters
{
    class Program
    {
        static void Main(string[] args)
        {

            ConnectedComponents alg = new ConnectedComponents(3, 3, new int[,] { { 1, 1, 1 }, { 2, 2, 2 }, { 2, 2, 1 } });
            Console.WriteLine(alg.Do());
        }
    }
}
