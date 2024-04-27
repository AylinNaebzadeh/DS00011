using System;
using System.Collections.Generic;
using System.Linq; 
namespace A5
{
    class Program
    {
        public static long BSearch(long[] a, long l, long h, long key)
        {
            if (h < l)
            {
                return -1;
            }
            long mid = ((l + h) / 2);
            long i = 0;
            if (key == a[mid])
            {
                for (i = 0; i <= mid; i++)
                {
                    if (a[mid] == a[i])
                    {
                        mid = i;
                        break;
                    }
                }
                return mid; 
            }

            else if (key < a[mid])
            {
                return BSearch(a, l, mid - 1, key);
            } 

            else
            {
                return BSearch(a, mid + 1, h, key);
            }
        }
        public static long BinarySearch(long[] a, long key)
        {
            return BSearch(a, 0, a.Length - 1, key);
        }

        public static int Check(int x, int[] y)
        {
            int count = 0;
            for (int i = 0; i < y.Length; i++)
            {
                if (x == y[i])
                {
                    count++;
                }
            }
            return count;
        }
        public static int MajorityElement(int[] a, int left, int right)
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

            int mid = (left + right) / 2;

            int[] m = new int[mid+1];
            for (int i = 0; i <= mid; i++)
            {
                m[i] = a[i];
            }

            int[] n = new int[a.Length - mid - 1];
            int j = 0;
            for (int i = mid + 1; i < a.Length; i++)
            {
                n[j] = a[i];
                j++; 
            }

            int x = MajorityElement(m, 0, m.Length - 1);
            int y = MajorityElement(n, 0, n.Length - 1);

            int tmp = a.Length;
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

        public static Tuple<long[], long> MergeForCountingInversions(long[] B,long[] C)
        {
            long number_of_pairs = 0;
            var D = new long[B.Length + C.Length];
            int i = 0; int j = 0;int k = 0;
            while (i < B.Length && j < C.Length)
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
                    number_of_pairs++;
                }
            }
            while (i < B.Length)
            {
                D[k] = B[i];
                k++;
                i++;
            }
            while (j < C.Length)
            {
                D[k] = C[j];
                k++;
                j++;
            }
            return new Tuple<long[], long>(D, number_of_pairs);
        }

        public static Tuple<long[], long> MergeSort(long[] a, long left, long right)
        {
            if (a.Length == 1)
            {
                return new Tuple<long[], long>(a, 0);
            }

            long m = (left + right) / 2;

            long[] b = new long[m + 1];
            for (long i = 0; i <= m; i++)
            {
                b[i] = a[i];
            }

            long[] c = new long[a.Length - m - 1];
            long j = 0;

            for (long i = m + 1; i < a.Length; i++)
            {
                c[j] = a[i];
                j++;
            }

            var (x, inv1) = MergeSort(b, 0, b.Length - 1);
            var (y, inv2) = MergeSort(c, 0, c.Length - 1);

            var (res, inv3) = MergeForCountingInversions(b, c);
            return new Tuple<long[], long>(res, inv1 + inv2 + inv3);
        }

        public static long Result(long len, long[] a)
        {
            return MergeSort(a, 0, len - 1).Item2;
        }
        static void Main(string[] args)
        {
            // long size = Convert.ToInt64(Console.ReadLine());
            // long[] MyArray;
            // MyArray = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt64);

            // long n = Convert.ToInt64(Console.ReadLine());
            // long[] B;
            // B = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt64);

            // long[] Input = new long[size];

            // for(int i = 0; i < Input.Length; i++)
            // {
            //     Input[i] = MyArray[i];
            // }

            // var res = new List<long>();

            // for(int i = 0; i < B.Length; i++)
            // {
            //     res.Add(BinarySearch(Input, B[i]));
            // }

            // System.Console.WriteLine(String.Join(" ", res.ToArray()));

            // ************************************************************************************

            // int n = Convert.ToInt32(Console.ReadLine());
            // int[] myArray;
            // myArray = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);
            // int ans = MajorityElement(myArray, 0, myArray.Length - 1);
            // if (ans != -1)
            // {
            //     System.Console.WriteLine(1);
            // }
            // else
            // {
            //     System.Console.WriteLine(0);
            // }
            // ************************************************************************************
            // var x = new long[]{6, 7, 8, 10};
            // var y = new long[]{3, 5, 9, 12};
            // var ans = MergeForCountingInversions(x, y);
            // foreach(var item in ans)
            // {
            //     System.Console.WriteLine(item);
            // }
            // var input = new long[]{38, 27, 43, 3, 9, 82, 10};
            // var output = MergeSort(input, 0, input.Length - 1);
            // foreach(var i in output)
            // {
            //     System.Console.WriteLine(i);
            // }

            long n = Convert.ToInt64(Console.ReadLine());
            long[] myArray;
            myArray = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt64);
            System.Console.WriteLine(Result(myArray.Length, myArray));
        }
    }
}

