using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q1MoneyChange: Processor
    {
        private static readonly int[] COINS = new int[] {1, 3, 4};

        public Q1MoneyChange(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        public long Solve(long n)
        {
            long[] MinNumberCoins = new long[n+1];
            MinNumberCoins[0] = 0;
            long NumCoins = 0;

            for (long m = 1; m <= n; m++)
            {
                MinNumberCoins[m] = long.MaxValue;
                for (long i = 0; i < COINS.Length; i++)
                {
                    if (m >= COINS[i])
                    {
                        NumCoins = MinNumberCoins[m - COINS[i]] + 1;
                        if (NumCoins < MinNumberCoins[m])
                        {
                            MinNumberCoins[m] = NumCoins;
                        }
                    }
                }
            }
            return MinNumberCoins[n];
        }
    }
}
