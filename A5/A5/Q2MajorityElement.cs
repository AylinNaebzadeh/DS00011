using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q2MajorityElement:Processor
    {

        public Q2MajorityElement(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        private static long Check(long x, long[] y)
        {
            long count = 0;
            for (long i = 0; i < y.Length; i++)
            {
                if (x == y[i])
                {
                    count++;
                }
            }
            return count;
        }
        public static long MajorityElement(long[] a, long left, long right)
        {
            // the array is empty
            if (left == right)
            {
                return -1;
            }

            // if the array had only one element
            if (left + 1 == right)
            {
                return a[left];
            }

            long mid = (left + right) / 2;

            long[] m = new long[mid+1];
            for (int i = 0; i <= mid; i++)
            {
                m[i] = a[i];
            }

            long[] n = new long[a.Length - mid - 1];
            long j = 0;
            for (long i = mid + 1; i < a.Length; i++)
            {
                n[j] = a[i];
                j++; 
            }

            long x = MajorityElement(m, 0, m.Length - 1);
            long y = MajorityElement(n, 0, n.Length - 1);

            long tmp = a.Length;
            if (Check(x, a) > tmp / 2)
            {
                return x;
            }
            if (Check(y, a) > tmp / 2)
            {
                return y;
            }
            else
            {
                return -1;
            }
        }

        public virtual long Solve(long n, long[] a)
        {
            long ans =  MajorityElement(a, 0, n - 1);
            if (ans != -1)
            {
                return 1;
            }
            else
            {
                return 0;
            }
        }
    }
}
