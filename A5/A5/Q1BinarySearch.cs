using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q1BinarySearch : Processor
    {
        public Q1BinarySearch(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long [], long[]>)Solve);

        private static long BinarySearch(long[] a, long l, long h, long key)
        {
            if (h < l)
            {
                return -1;
            }
            long mid = (l + h) / 2;
            if (key == a[mid])
            {
                return mid;
            }
            else if (key < a[mid])
            {
                return BinarySearch(a, l, mid - 1, key);
            }
            else
            {
                return BinarySearch(a, mid + 1, h, key);
            }
        }
        public virtual long[] Solve(long [] a, long[] b) 
        {
            long b_lenght = b.Length;
            long[] result = new long[b_lenght];
            for (long i = 0; i < b_lenght; i++)
            {
                result[i] = BinarySearch(a, 0, a.Length - 1, b[i]);
            }
            return result;
        }
    }
}
