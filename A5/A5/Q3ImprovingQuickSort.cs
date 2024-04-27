using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q3ImprovingQuickSort:Processor
    {
        public Q3ImprovingQuickSort(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[]>)Solve);

        public static void Swap(ref long a,ref long b)
        {
            long tmp = a;
            a = b;
            b = tmp;
        } 
        public static Tuple<long, long> Partition3(long[] arr, long l, long r)
        {
            long pivot = arr[l];
            long m1 = l;
            long m2 = r;
            long i = l;
            while(i <= m2)
            {
                if (arr[i] < pivot)
                {
                    Swap(ref arr[i], ref arr[m1]);
                    m1++;
                }
                else if (arr[i] > pivot)
                {
                    Swap(ref arr[i], ref arr[m2]);
                    m2--;
                }
                else
                {
                    i++;
                }
            }
            return new Tuple<long, long>(m1, m2);
        }

        public static void QuickSortWithPartition3(long[] a, long l, long r)
        {
            if (l >= r)
            {
                return;
            }
            Random random= new Random();
            long k = l + random.Next() % (r - l + 1);
            Swap(ref a[l],ref a[k]);
            var p = Partition3(a, l, r);
            QuickSortWithPartition3(a, l, p.Item1 - 1);
            QuickSortWithPartition3(a, p.Item2 + 1, r);
        }
        public virtual long[] Solve(long n, long[] a)
        {
            QuickSortWithPartition3(a, 0, n - 1);
            return a;
        }
    }
}
