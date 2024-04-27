using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C3
{
    public class Q1Array : Processor
    {
        public Q1Array(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) => TestTools.Process(inStr, (Func<long, long[], long>)Solve);
        
        // T(n) = 2T(n / 2) + theta(n)
        public static long Solve(long n, long[] a)
        {
            return MySolve(0 , n - 1, a);
        }

        private static long MySolve(long left, long right, long[] a)
        {
            if (left >= right)
            {
                return a[left];
            }

            long mid = (left + right) / 2;

            long SumR = 0;
            long MaxR = 0;

            for (long i = mid+1; i <= right; i++)
            {
                SumR += a[i];
                MaxR = Math.Max(MaxR, SumR);
            }

            long SumL = 0;
            long MaxL = 0;

            for (long i = mid; i >= left; i--)
            {
                SumL += a[i];
                MaxL = Math.Max(MaxL, SumL);
            }

            long z = MaxR + MaxL;

            long x = MySolve(left, mid, a);
            long y = MySolve(mid + 1, right, a);
            return Math.Max(Math.Max(x, y), z);

        }
    }
}
