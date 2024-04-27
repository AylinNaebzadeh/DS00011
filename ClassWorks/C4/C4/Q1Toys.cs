using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C4
{
    public class Q1Toys : Processor
    {
        public Q1Toys(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long a = first[0];
            long [] arr = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(a, arr).ToString();
        }
        public static long RangeSum(long start, long end, long[] a)
        {
            long sum = 0;
            for (long i = start; i <= end; i++)
            {
                sum += a[i];
            }
            return sum;
        }
        public static long Solve(long a, long[] arr)
        {
            long[] DpArray = new long[a];
            // one box
            DpArray[a-1] = arr[a-1];
            // two box
            DpArray[a-2] = arr[a-2] + arr[a-1];
            // three box
            DpArray[a-3] = arr[a-3] + arr[a-2] + arr[a-1];

            long[] SumArray = new long[a];
            SumArray[a-1] = arr[a-1];
            SumArray[a-2] = arr[a-1] + arr[a-2];
            for (long i = a - 3; i >= 0; i--)
            {
                SumArray[i] = arr[i] + SumArray[i+1];
            }

            for (long i = a - 4; i >= 0; i--)
            {
                long one_box = arr[i] + SumArray[i+1] - DpArray[i+1];
                long two_box = arr[i] + arr[i+1] + SumArray[i+2] - DpArray[i+2];
                long three_box = arr[i] + arr[i+1] + arr[i+2] + SumArray[i+3] - DpArray[i+3];
                DpArray[i] = Math.Max(one_box,Math.Max(two_box, three_box));
            }
            return DpArray[0];
        }
    }
}
