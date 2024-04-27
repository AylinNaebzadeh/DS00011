using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A3
{
    public class Q1MergeSort : Processor
    {
        public Q1MergeSort(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public static long[] Merge(long[] B,long[] C)
        {
            var D = new long[B.Length + C.Length];
            int i = 0; int j = 0; int k = 0;
            while( i < B.Length  && j < C.Length)
            {
                long b = B[i];
                long c = C[j];
                if (b <= c)
                {
                    D[k] = b;
                    k++;
                    i++;
                }
                else
                {
                    D[k] = c;
                    k++;
                    j++;
                }
            }
            while(i < B.Length)
            {
                D[k] = B[i];
                k++;
                i++;
            }
            while(j < C.Length)
            {
                D[k] = C[j];
                k++;
                j++;
            }
            return D;
        }
        public long[] Solve(long n, long[] a)
        {
            // n --> size of a
            if (n == 1)
            {
                return a;
            }

            long m = 0;

            m = n / 2;

            long[] b = new long[m];
            for  (long i = 0; i < m; i++)
            {
                b[i] = a[i];
            }

            long[] c = new long[n - m];
            long j = 0;

            if(n % 2 == 0)
            {
                for (long i = n - m; i < n; i++)
                {
                    c[j] = a[i];
                    j++;
                }
            }

            else
            {
                for (long i = n - m - 1; i < n; i++)
                {
                    c[j] = a[i];
                    j++;
                }
            }


            b = Solve(b.Length, b);
            c = Solve(c.Length, c);

            var ans = Merge(b, c);

            return ans;
        }
    }
}
