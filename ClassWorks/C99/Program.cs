using System;
using System.Linq;
using System.Text;
using Priority_Queue;
namespace C99
{
    class Program
    {
        public static String Solve(long n,long[] arr)
        {
            double[] res = new double[n];
            // اولین میانه میشه همون عدد اولی که اضافه میشه
            double last_m = arr[0];
            // برای نصفه بزرگتر
            // از کوچیک به بزرگ مرتب میشه
            SimplePriorityQueue<double> MinHeap = new SimplePriorityQueue<double>();
            // برای نصفه کوچیکتر
            // از بزرگ به کوچیک مرتب میشه
            SimplePriorityQueue<double> MaxHeap = new SimplePriorityQueue<double>();
            MaxHeap.Enqueue(-last_m, -(float)last_m);
            for (int i = 1; i < n; i++)
            {
                long to_be_added = arr[i];
                if (MinHeap.Count == MaxHeap.Count)
                {
                    if (to_be_added < last_m)
                    {
                        MaxHeap.Enqueue(-to_be_added, -to_be_added);
                        last_m = -MaxHeap.First();
                    }
                    else
                    {
                        MinHeap.Enqueue(to_be_added, to_be_added);
                        last_m = MinHeap.First();
                    }
                }

                else if (MaxHeap.Count > MinHeap.Count)
                {
                    if (to_be_added < last_m)
                    {
                        MinHeap.Enqueue(-MaxHeap.First(), -(float)MaxHeap.First());
                        MaxHeap.Dequeue();
                        MaxHeap.Enqueue(-to_be_added, -to_be_added);
                    }
                    else
                    {
                        MinHeap.Enqueue(to_be_added, to_be_added);
                    }
                    last_m = (double)(-MaxHeap.First() + MinHeap.First()) / 2;
                }

                else
                {
                    if (to_be_added > last_m)
                    {
                        MaxHeap.Enqueue(-MinHeap.First(), -(float)MinHeap.First());
                        // change it to dequeue
                        MinHeap.Dequeue();
                        MinHeap.Enqueue(to_be_added, to_be_added);
                    }
                    else
                    {
                        MaxHeap.Enqueue(-to_be_added, -to_be_added);
                    }
                    last_m = (double)(-MaxHeap.First() + MinHeap.First()) / 2;
                }
                res[i] = last_m;
            }
            var ans = res.Select(x => String.Format("{0:0.0}", x));
            return String.Join('\n',ans);
        }
        static void Main(string[] args)
        {
            // 7352
            
            long[] input = new long[]{12, 4, 5, 3, 8, 7};
            string res = Solve(6, input);
            System.Console.WriteLine(res);
            // SimplePriorityQueue<double> MinHeap = new SimplePriorityQueue<double>();

        }
    }
}
