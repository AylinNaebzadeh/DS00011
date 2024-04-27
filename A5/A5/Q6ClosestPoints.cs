using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A5
{
    public class Q6ClosestPoints : Processor
    {
        public Q6ClosestPoints(string testDataName) : base(testDataName)
        { }
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], double>)Solve);
        
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
    }
}