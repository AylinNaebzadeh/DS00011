using System;
using System.Collections.Generic;
using System.Linq;

namespace coursera
{
    class Program
    {

        #region OL
        private static long BinarySearchInStarts(long[] a, long l, long h, long key)
        {
            if (h < l)
            {
                return h;
            }
            long mid = (l + h) / 2;
            if (key == a[mid])
            {
                while(mid + 1 < a.Length && a[mid+1] == key)
                {
                    mid++;
                }
                return mid;
            }
            else if (key < a[mid])
            {
                return BinarySearchInStarts(a, l, mid - 1, key);
            }
            else
            {
                return BinarySearchInStarts(a, mid + 1, h, key);
            }
        }
        private static long BinarySearchInEnds(long[] a, long l, long h, long key)
        {
            if (h < l)
            {
                return l;
            }
            long mid = (l + h) / 2;
            if (key == a[mid])
            {
                while(mid - 1 > -1 && a[mid-1] == key)
                {
                    mid--;
                }
                return mid;
            }
            else if (key < a[mid])
            {
                return BinarySearchInEnds(a, l, mid - 1, key);
            }
            else
            {
                return BinarySearchInEnds(a, mid + 1, h, key);
            }
        }
        public static long[] Solve(long[] points, long[] startSegments, long[] endSegment)
        {
            long s_length = startSegments.Length;
            Array.Sort(startSegments);
            Array.Sort(endSegment);
            long p_length = points.Count();
            long[] res = new long[p_length];
            long count = 0;
            for (long i = 0; i < p_length; i++)
            {
                // if (points[i] < startSegments.Min() || points[i] > endSegment.Max())
                // {
                //     count = 0;
                //     continue;
                // }
                long index_in_s = BinarySearchInStarts(startSegments, 0, s_length - 1, points[i]);
                long index_in_e = BinarySearchInEnds(endSegment, 0, s_length - 1, points[i]);
                count = index_in_s - index_in_e + 1;
                res[i] = count; 
            }
            return res;
        }
        #endregion OL

        #region CP
        public static List<T> SubList<T>(List<T> input, int l, int h)
        {
            var newList = new List<T>();
            for (int i = l; i < h; i++)
            {
                newList.Add(input[i]);
            }
            return newList;
        }

        public static double CalculateDistance(Tuple<long , long> p1, Tuple<long, long> p2)
        {
            return Math.Sqrt((Math.Pow((p1.Item1 - p2.Item1), 2) + Math.Pow((p1.Item2 - p2.Item2), 2)));
        }

        public static double ClosestPoint(List<Tuple<long, long>> input, long n)
        {
            if (input.Count <= 3)
            {
                double min_base = CalculateDistance(input[0], input[1]);
                for (int i = 0; i < input.Count; i++)
                {
                    for (int j = i + 1; j < input.Count; j++)
                    {
                        if (CalculateDistance(input[i], input[j]) < min_base)
                        {
                            min_base = CalculateDistance(input[i], input[j]);
                        }
                    }
                }
                return min_base;
            }

            double d1 = ClosestPoint(SubList(input, 0, (int) input.Count / 2), 0);
            double d2 = ClosestPoint(SubList(input, (int) input.Count / 2, (int) input.Count), 0);
            double d = Math.Min(d1, d2);
            // we filter the initial point set and keep only those points whose x-distance to the middle line does not exceed d
            // input.FindAll(t => t.Item1 > d).ForEach(t => input.Remove(t));
            // if (input.Count < 8)
            // {
            //     return d;
            // }
            var sortedNewList = input.OrderBy(y => y.Item2).ToList();
            double min = double.MaxValue;

            for (int i = 0; i < sortedNewList.Count(); i++)
            {
                for (int j = i + 1; j < sortedNewList.Count() && sortedNewList[j].Item2 - sortedNewList[i].Item2 < d; j++)
                {
                    if (CalculateDistance(sortedNewList[i], sortedNewList[j]) < min)
                    {
                        min = CalculateDistance(sortedNewList[i], sortedNewList[j]);
                    }
                }
            }
            return Math.Min(min, d);

        }

        static bool IsWholeNumber(double x) 
        {
            return Math.Abs(x % 1) < double.Epsilon;
        }
        public static double Solve(long n, long[] x_cordinates, long[] y_cordinates)
        {
            var ListOfPoints = x_cordinates.Zip(y_cordinates, (x, y) => new Tuple<long, long>(x, y)).ToList();
            // Sort the list base on x coordinates
            var SortedList = ListOfPoints.OrderBy(i => i.Item1).ToList();
            double ans =  ClosestPoint(SortedList, SortedList.Count);
            if (IsWholeNumber(ans))
            {
                return ans;
            }
            return Math.Round(ans, 4);
        }
        #endregion CP
        static void Main(string[] args)
        {
            // long[] first_line;
            // first_line = Array.ConvertAll(Console.ReadLine().Trim().Split(' ') , Convert.ToInt64);
            // long[] segment;
            // long[] starts = new long[first_line[0]];
            // long[] ends = new long[first_line[0]];
            // for (long i = 0; i < first_line[0]; i++)
            // {
            //     segment = Array.ConvertAll(Console.ReadLine().Trim().Split(' ') , Convert.ToInt64);
            //     starts[i] = segment[0];
            //     ends[i] = segment[1];
            // }
            // long[] p = new long[first_line[1]];
            // p = Array.ConvertAll(Console.ReadLine().Trim().Split(' ') , Convert.ToInt64);
            // var res = Solve(p, starts, ends);
            // for (long i = 0; i < p.Count(); i++)
            // {
            //     System.Console.Write(res[i] + " ");
            // }
            // **********************************************************************************************
            long count = Convert.ToInt64(Console.ReadLine());
            long[] point = new long[count];
            long[] x_cordinates = new long[count];
            long[] y_cordinates = new long[count];
            for (long i = 0; i < count; i++)
            {
                point = Array.ConvertAll(Console.ReadLine().Trim().Split(' ') , Convert.ToInt64);
                x_cordinates[i] = point[0];
                y_cordinates[i] = point[1];
            }
            System.Console.WriteLine(Solve(count, x_cordinates, y_cordinates));
        }
    }
}
