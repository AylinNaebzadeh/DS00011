using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q2PartitioningSouvenirs : Processor
    {
        public Q2PartitioningSouvenirs(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);
        public static long Solve(long souvenirsCount, long[] souvenirs)
        {
            long allSouvenirsSum = souvenirs.Sum();
            if (souvenirsCount < 3 || allSouvenirsSum % 3 != 0)
            {
                return 0;
            }
            long res =  Partition3((int) (allSouvenirsSum / 3), souvenirsCount, souvenirs);
            if (res != 0)
            {
                return 1;
            }
            return 0;
        }
        private static long Partition3(long TotalWeight, long souvenirsCount, long[] souvenirs)
        {
            long[,] DP = new long[TotalWeight + 1, souvenirsCount + 1];
            long count = 0;
            for (long i = 1; i < TotalWeight + 1; i++)
            {
                for (long j = 1; j < souvenirsCount + 1; j++)
                {
                    DP[i, j] = DP[i, j - 1];
                    if (souvenirs[j - 1] <= i)
                    {
                        DP[i, j] = Math.Max(DP[i, j - 1], DP[i - souvenirs[j - 1], j - 1] + souvenirs[j - 1]); 
                        if (DP[i, j] == TotalWeight)
                        {
                            count++;
                        }
                    }
                }
            }
            return count;
        }
    }
}
