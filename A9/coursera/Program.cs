using System;
using System.Collections.Generic;
using System.Linq;

namespace A99
{

    public class DisjointSets
    {
        public long[] parents;
        public long[] rowsCount;
        public DisjointSets(long[] tableSizes)
        {
            long count = tableSizes.Count();
            parents = new long[count];
            rowsCount = new long[count];
            for (long i = 0; i < count; i++)
            {
                parents[i] = i;
                rowsCount[i] = tableSizes[i];
            }
        }
        public long FindParent(long table)
        {
            while (table != parents[table])
            {
                table = parents[table];
            }
            return table;
        }
        public void Union(long i, long j)
        {
            long i_id = FindParent(i);
            long j_id = FindParent(j);
            
            if (i_id == j_id)
            {
                return;
            }
            parents[i_id] = j_id;
            rowsCount[j_id] += rowsCount[i_id];
            rowsCount[(int)i] = 0;
            // maxTableSize = ds.Max(obj => obj.size);
        }
    }
    class Program
    {
        #region ParallelProcessing
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

        public static Tuple<long, long>[] Solve(long threadCount, long[] jobDuration)
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
        #endregion


        #region MergingTables
        public static long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
        { 
            long count = targetTables.Length;
            long[] res = new long[count];
            DisjointSets tables = new DisjointSets(tableSizes);

            for (long i = 0; i < targetTables.Length; i++)
            {
                targetTables[i] -= 1;
                sourceTables[i] -= 1;
                tables.Union(targetTables[i], sourceTables[i]);
                res[i] = tables.rowsCount.Max();
            }
            return res;
        }

        public static long[] mergingTables(long[] tableSizes, long[] targetTables, long[] sourceTables)
        {
            long[] parent = new long[tableSizes.Length];
            long[] rank = new long[tableSizes.Length];
            List<long> maxTableSize = new List<long>();
            for (int i = 0; i < tableSizes.Length; i++)
            {
                parent[i] = i;
                rank[i] = tableSizes[i];
            }
            for (int i = 0; i < targetTables.Length; i++)
            {
                long x = targetTables[i] - 1;
                long y = sourceTables[i] - 1;
                long parent_x = parent[x];
                long parent_y = parent[y];
                long rank_x = rank[x];
                long rank_y = rank[y];
                if (parent_x != parent_y)
                {
                    for (int j = 0; j < parent.Length; j++)
                    {
                        if (parent[j] == parent_x)
                        {
                            rank[j] += rank_y;
                        }
                        if (parent[j] == parent_y)
                        {
                            rank[j] += rank_x;
                        }
                        if (parent[j] == parent_x)
                        {
                            parent[j] = parent_y;
                        }
                    }
                }
                maxTableSize.Add(rank.Max());
            }
            return maxTableSize.ToArray();
        }

        public static long[] Solve2(long[] tableSizes, long[] targetTables, long[] sourceTables)
        {

            long[] Rank = new long[tableSizes.Length];
            long[] Parents = new long[tableSizes.Length];
            long[] result = new long[targetTables.Length];
            for (long i = 0; i < tableSizes.Length; i++)
            {
                Rank[i] = tableSizes[i];
                Parents[i] = i;
            }
            for (long i = 0; i < targetTables.Length; i++)
            {
                Union(sourceTables[i] - 1, targetTables[i] - 1, ref Parents, ref Rank);
                result[i] = Rank.Max();
            }
            return result;
        }
        public static long Find(long i, long[] Parents)
        {
            while (i != Parents[i])
            {
                i = Parents[i];
            }
            return i;
        }
        public static void Union(long i, long j, ref long[] Parents, ref long[] Rank)
        {
            long First = Find(i, Parents);
            long Second = Find(j, Parents);
            if (First == Second) return;
            Parents[First] = Second;
            Rank[Second] += Rank[First];
            Rank[i] = 0;
        }
        #endregion

        static void Main(string[] args)
        {
            // long count = Convert.ToInt64(Console.ReadLine());
            // long[] input = new long[count];
            // input = Array.ConvertAll(Console.ReadLine().Trim().Split(' ') , Convert.ToInt64);
            // var res = BuildMinHeap(input);
            // System.Console.WriteLine(res.Length);
            // for (int i = 0; i < res.Length; i++)
            // {
            //     System.Console.WriteLine(res[i].Item1 + " " + res[i].Item2);
            // }

            // *************************************************************************
            // long[] first_line = new long[2];
            // first_line = Array.ConvertAll(Console.ReadLine().Trim().Split(' ') , Convert.ToInt64);

            // long[] input = new long[first_line[1]];
            // input = Array.ConvertAll(Console.ReadLine().Trim().Split(' ') , Convert.ToInt64);
            // var res = Solve(first_line[0], input);
            // for (long i = 0; i < res.Length; i++)
            // {
            //     System.Console.WriteLine(res[i].Item1 + " " + res[i].Item2);
            // }

            // **************************************************************************

            var first_line = Array.ConvertAll(Console.ReadLine().Trim().Split(' ') , Convert.ToInt64);
            long[] second_line = new long[first_line[0]];
            second_line = Array.ConvertAll(Console.ReadLine().Trim().Split(' ') , Convert.ToInt64);
            long[] destinations = new long[first_line[1]];
            long[] sources = new long[first_line[1]];
            long[] query;
            for (long i = 0; i < first_line[1]; i++)
            {
                query = Array.ConvertAll(Console.ReadLine().Trim().Split(' ') , Convert.ToInt64);
                destinations[i] = query[0];
                sources[i] = query[1];
            }
            var res = Solve2(second_line, destinations, sources);
            for (long i = 0; i < res.Length; i++)
            {
                System.Console.WriteLine(res[i]);
            }

        }

    }
}
