using System;
using System.Collections.Generic;
using System.Linq;

namespace coursera
{
    class Program
    {
        public static long Solve(long n)
        {
            int[] COINS = new int[] {1, 3, 4};
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


        static void Main(string[] args)
        {
            int total_amount = Convert.ToInt32(Console.ReadLine());
            System.Console.WriteLine(Solve(total_amount));
        }
    }
}

