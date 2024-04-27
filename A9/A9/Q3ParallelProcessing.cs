using System;
using System.Collections.Generic;
using TestCommon;

namespace A9
{
    public class Q3ParallelProcessing : Processor
    {
        public Q3ParallelProcessing(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], Tuple<long, long>[]>)Solve);

        private static void Swap(ref long a, ref long b)
        {
            long tmp = a;
            a = b;
            b = tmp;
        }
        public static void HeapifyTree(long[] array, long i)
        {
            long array_length = array.Length;
            // --> 0
            long smallest_index = i;
            // --> 1, 3
            long left_child_index = 2 * smallest_index + 1;
            // 2, 4
            long right_child_index = 2 * smallest_index + 2;

            while (left_child_index < array_length && right_child_index < array_length && (array[smallest_index] > array[right_child_index] || array[smallest_index] > array[left_child_index]))
            {
                if (Math.Min(array[left_child_index], array[right_child_index]) == array[left_child_index])
                {
                    Swap(ref array[smallest_index], ref array[left_child_index]);
                    smallest_index = left_child_index;
                }
                else
                {
                    Swap(ref array[smallest_index], ref array[right_child_index]);
                    smallest_index = right_child_index;
                }
                left_child_index = 2 * smallest_index + 1;
                right_child_index = 2 * smallest_index + 2;
            }

            if (left_child_index < array_length && array[smallest_index] > array[left_child_index])
            {
                Swap(ref array[smallest_index], ref array[left_child_index]);
            }
        }
        public Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
        {
            long job_count = jobDuration.Length;
            var res = new Tuple<long, long>[job_count];
            res[0] = Tuple.Create((long)0, (long)0);
            long[] thread_tree = new long[threadCount];
            for (long i = 0; i < job_count - 1; i++)
            {
                thread_tree[0] += jobDuration[i];
                HeapifyTree(thread_tree, 0);
                res[i + 1] = Tuple.Create((i+1) % threadCount, thread_tree[0]); 
            }
            return res;
        }
    }
}
