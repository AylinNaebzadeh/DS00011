using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q1ChangingMoney : Processor
    {
        public Q1ChangingMoney(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>) Solve);

        // 24 --> 24 % 10 --> q = 2 , r = 4
        // 3 while
        public static long Solve(long money)
        {
            var coins = new long[]{10, 5, 1};
            long res = 0;
            int i = 0;
            while (money > 0)
            {
                if (coins[i] <= money)
                {
                    res += money / coins[i];
                    money %= coins[i]; 
                }
                else
                {
                    i++;
                }
            }
            return res;
        }


    }
}
