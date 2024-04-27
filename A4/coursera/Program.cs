using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace coursera
{
    public class Segments
    {
        public Segments(int start, int end)
        {
            this.Start = start;
            this.End = end;
        }
        public int Start { get; set; }
        public int End { get; set; }
    }


    class Program
    {
        public static long MoneyChange(long money)
        {
            var coins = new long[]{10, 5, 1};
            long res = 0;
            int i = 0;
            while (money > 0)
            {
                if (coins[i] <= money)
                {
                    res += money / coins[i];
                    money %= coins[i]; 
                }
                else
                {
                    i++;
                }
            }
            return res;
        }


        ///<summary>
        // You are going to travel to another city that is located 𝑑 miles away from your home city. Your car can travel
        // at most 𝑚 miles on a full tank and you start with a full tank. Along your way, there are gas stations at
        // distances stop1, stop2, . . . , stop𝑛 from your home city.
        ///</summary>
        static int CarRefill(int dist, int tank, int[] stops)
        {
            // dist --> kole masafati ke bayad tey konim
            // tank --> mizan masafati ke mitonim ba bak por tey konim
            int numRefills = 0;
            int currentRefill = 0;
            int len = stops.Length;
            // Array.Resize<int>(ref stops , stops.Length + 2);


            int[] newstops = new int[len + 2];

            for (int i = 1; i <= len; i++)
                newstops[i] = stops[i - 1];

            newstops[0] = 0;
            newstops[newstops.Length - 1] = dist;

            while (currentRefill <= newstops.Length - 2)
            {
                int lastRefill = currentRefill;
                while ((currentRefill <= (newstops.Length - 2)) && (newstops[currentRefill + 1] - newstops[lastRefill] <= tank))
                {
                    currentRefill++;
                }
                if (currentRefill == lastRefill)
                {
                    return -1;
                }
                if (currentRefill <= newstops.Length - 2)
                    numRefills++;
            }
            return numRefills;
        }

        // https://stackoverflow.com/questions/1291483/leave-only-two-decimal-places-after-the-dot
        // https://stackoverflow.com/questions/6133362/how-to-unifiy-two-arrays-in-a-dictionary
        static double KnapsackLINQ(double capacity, double[] weights, double[] values)
        {
            double value = 0.0;

            // var dictionary = weights.Zip(values, (w, v) => new { w, v }).ToLookup(item => item.w, item => item.v / item.w).ToDictionary(t => t.Key, t => t.First());

            var mylist = weights.Zip(values, (w,v) => new Tuple<double, double>(w, v/w)).ToList();

            // var mylist = dictionary.ToList();
            // mylist.Sort((pair1, pair2) => pair1.Value.CompareTo(pair2.Value));
            // double Max = mylist.LastOrDefault().Value;
            // var myordereddic = mylist.ToDictionary(x => x.Key, x => x.Value).OrderByDescending(x => x.Value);
            // var mydic = myordereddic.ToDictionary(x => x.Key, x => x.Value);

            var SortedValues = mylist.OrderByDescending(p => p.Item2);

            double Max = SortedValues.FirstOrDefault().Item2;


            double a = 0;
            double wi = 0.0;
            foreach (Tuple<double, double> kvp in SortedValues)
            {
                if (capacity == 0)
                {
                    return value;
                }

                wi = kvp.Item1;
                a = Math.Min(wi, capacity);
                value += a * kvp.Item2;
                wi -= a;

                capacity -= a;
            }
            return value;
        }



        // static long MaximumAdvertisementRevenueRec(int[] a , int[] b)
        // {
        //     long result = 0;
        //     if( a.Length + b.Length == 2)
        //         return a[0] * b[0];

        //     if( a.Length == 0)
        //         return 0;

        //     else{
        //         var mylist = a.ToList();

        //         int maxnuma = 0;
        //         foreach (int x in mylist)
        //         {
        //             if( x > maxnuma)
        //             {
        //                 maxnuma = x;
        //             }
        //         }

        //         var mysecondlist = b.ToList();

        //         int maxnumb = 0;
        //         foreach(int y in mysecondlist)
        //         {
        //             if( y > maxnumb )
        //             {
        //                 maxnumb = y;
        //             }
        //         }

        //         for(int i=0; i<a.Length; i++)
        //         {
        //             result += maxnuma * maxnumb;
        //             mylist.Remove(maxnuma);
        //             mysecondlist.Remove(maxnumb);
        //             MaximumAdvertisementRevenueRec( mylist.ToArray() , mysecondlist.ToArray());
        //         }
        //     }
        //     return result;
        // }


        static long MaximumAdvertisementRevenue(int[] a, int[] b)
        {
            long res = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] < a[j])
                    {
                        int tmp = a[i];
                        a[i] = a[j];
                        a[j] = tmp;
                    }
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                for (int j = i + 1; j < b.Length; j++)
                {
                    if (b[i] < b[j])
                    {
                        int tmp = b[i];
                        b[i] = b[j];
                        b[j] = tmp;
                    }
                }
            }

            for (int i = 0; i < a.Length; i++)
            {
                res += Convert.ToInt64(a[i]) * Convert.ToInt64(b[i]);
            }
            return res;
        }



        static List<int> PointsCoveredSorted(Segments[] segments)
        {
            var answer = new List<int>();
            var SortedSegmentsList = segments.OrderBy(s => s.End).ToList();
            int p = SortedSegmentsList.FirstOrDefault().End;
            for (int i = 0; i < SortedSegmentsList.Count; i++)
            {
                if ( !(p <= SortedSegmentsList[i].End && p >= SortedSegmentsList[i].Start) )
                {
                    p = SortedSegmentsList.FirstOrDefault().End;
                }
                else
                {
                    SortedSegmentsList.Remove(SortedSegmentsList[i]);
                    answer.Add(p);
                }
                i--;
            }
            return answer.Distinct().ToList();
        }

        static bool IsGreaterOrEqual(string s1, string s2)
        {
            if (string.Compare(s1 + s2, s2 + s1) == 1)
            {
                return true;
            }
            return false;
        }

        static string LargestNumber(string[] digits)
        {
            List<string> Digits = digits.ToList();
            var answer = new List<string>();
            while (Digits.Count != 0)
            {
                // try StringBuilder

                var MaxDigit = new StringBuilder(" ", Digits.Count);
                var Max = MaxDigit.ToString();
                foreach (var d in Digits)
                {
                    if (IsGreaterOrEqual(d, Max))
                    {
                        Max = d;
                    }
                }
                answer.Add(Max);
                Digits.Remove(Max);
            }
            string s = string.Join("", answer);
            return s;
        }

        static List<long> MaximumNumberOfPrizes(long n)
        {
            var ans = new List<long>();
            long sum = 0;
            long tmp = n;

            for (long i = n - 1; i >= 0; i--)
            {
                n = tmp - i;
                sum += n;
                if( sum >= tmp)
                {
                    break;
                }
                ans.Add(n);
            }

            long total = ans.Sum(s => Convert.ToInt64(s));
            if (total == tmp)
            {
                return ans;
            }

            long rem = tmp - total;
            if (ans.Contains(rem))
            {
                ans.Remove(ans.LastOrDefault());
                ans.Add(tmp - ans.Sum(ss => Convert.ToInt64(ss)));
            }
            else
            {
                ans.Add(rem);
            }
            return ans;
        }



        static void Main(string[] args)
        {
            
            // int total_amount = Convert.ToInt32(Console.ReadLine());
            // System.Console.WriteLine(MoneyChange(total_amount));
            //*******************************************************************************************
            // int dist = Convert.ToInt32(Console.ReadLine());
            // int max = Convert.ToInt32(Console.ReadLine());
            // int numberofstations = Convert.ToInt32(Console.ReadLine());
            // int[] stops = new int[numberofstations];

            // stops = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);

            // System.Console.WriteLine(CarRefill(dist, max, stops));



            //**********************************************************************************************
            // int[] firstline;
            // firstline = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);
            // List<double> values = new List<double>();
            // List<double> weights = new List<double>();

            // double[] myarray;
            // for (int i = 0; i < firstline[0]; i++)
            // {
            //     myarray = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToDouble);
            //     values.Add(myarray[0]);
            //     weights.Add(myarray[1]);
            // }
            // double[] v = values.ToArray();
            // double[] w = weights.ToArray();

            // double ans = KnapsackLINQ(firstline[1], w, v);
            // System.Console.WriteLine(String.Format("{0:0.0000}" , ans));


            //***********************************************************************************************
            // int n = Convert.ToInt32(Console.ReadLine());
            // int[] a;
            // a = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);

            // int[] b;
            // b = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt32);

            // System.Console.WriteLine(MaximumAdvertisementRevenue(a , b));
            //*************************************************************************************************


            // int number_of_segments = Convert.ToInt32(Console.ReadLine());
            // List<Segments> s = new List<Segments>();

            // int[] myarray;
            // for(int i=0; i<number_of_segments; i++)
            // {
            //     myarray = Array.ConvertAll(Console.ReadLine().Trim().Split(' ') , Convert.ToInt32);
            //     var segment = new Segments(myarray[0] , myarray[1]);
            //     s.Add(segment);
            // }

            // var anslist = PointsCoveredSorted(s.ToArray());

            // System.Console.WriteLine(anslist.Count);

            // for (int i = 0; i < anslist.Count; i++)
            // {
            //     System.Console.Write(anslist[i] + " ");
            // }

            //*****************************************************************************************************

            // System.Console.WriteLine(MaximumNumberOfPrizes(8));
            //*******************************************************************************************************

            // int size_of_array = Convert.ToInt32(Console.ReadLine());
            // long[] myarray;
            // var mylist = new List<string>();

            // myarray = Array.ConvertAll(Console.ReadLine().Trim().Split(' ') , Convert.ToInt64);
            // for( int i = 0; i<myarray.Length; i++)
            // {
            //     string item = myarray[i].ToString();
            //     mylist.Add(item);
            // }

            // System.Console.WriteLine(LargestNumber(mylist.ToArray()));

            //*******************************************************************************************************

            int n = Convert.ToInt32(Console.ReadLine());
            var mylist = MaximumNumberOfPrizes(n);
            System.Console.WriteLine(mylist.Count);
            for (int i = 0; i < mylist.Count; i++)
            {
                System.Console.Write(mylist[i] + " ");
            }

            //********************************************************************************************************
        }
    }
}



