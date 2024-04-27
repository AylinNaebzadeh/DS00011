using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Priority_Queue;
using TestCommon;

namespace C9
{
    public class Q1Median : Processor
    {
        public Q1Median(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C7Processors.ProcessQ1Median(inStr, Solve);

        public String Solve(long n,long[] arr)
        {
            double[] res = new double[n];
            // اولین میانه میشه همون عدد اولی که اضافه میشه
            res[0] = arr[0];
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
                        last_m = -MaxHeap.Dequeue();
                        MaxHeap.Enqueue(-last_m, -(float)last_m);
                    }
                    else
                    {
                        MinHeap.Enqueue(to_be_added, to_be_added);
                        last_m = MinHeap.Dequeue();
                        MinHeap.Enqueue(last_m, (float)last_m);
                    }
                }

                else if (MaxHeap.Count > MinHeap.Count)
                {
                    if (to_be_added < last_m)
                    {
                        double dequeued = MaxHeap.Dequeue();
                        MinHeap.Enqueue(-dequeued, -(float)dequeued);
                        MaxHeap.Enqueue(-to_be_added, -to_be_added);
                    }
                    else
                    {
                        MinHeap.Enqueue(to_be_added, to_be_added);
                    }
                    double max_dequeued = MaxHeap.Dequeue();
                    double min_dequeued = MinHeap.Dequeue();
                    last_m = (double)(-max_dequeued + min_dequeued) / 2;
                    MaxHeap.Enqueue(max_dequeued, (float)max_dequeued);
                    MinHeap.Enqueue(min_dequeued, (float)min_dequeued);
                }

                else
                {
                    if (to_be_added > last_m)
                    {
                        double dequeued = MinHeap.Dequeue();
                        MaxHeap.Enqueue(-dequeued, -(float)dequeued);
                        MinHeap.Enqueue(to_be_added, to_be_added);
                    }
                    else
                    {
                        MaxHeap.Enqueue(-to_be_added, -to_be_added);
                    }
                    double max_dequeued = MaxHeap.Dequeue();
                    double min_dequeued = MinHeap.Dequeue();
                    last_m = (double)(-max_dequeued + min_dequeued) / 2;
                    MaxHeap.Enqueue(max_dequeued, (float)max_dequeued);
                    MinHeap.Enqueue(min_dequeued, (float)min_dequeued);
                }
                res[i] = last_m;
            }
            var ans = res.Select(x => String.Format("{0:0.0}", x));
            return String.Join('\n',ans);
        }
    }
}
