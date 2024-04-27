class ConvertArrayIntoHeap
{
        private static void Swap(ref long a, ref long b)
        {
            long tmp = a;
            a = b;
            b = tmp;
        }

        
        public static void HeapifyTree(long[] array, long i, List<Tuple<long, long>> res)
        {
            long array_length = array.Length;
            // --> 0
            long smallest_index = i;
            // --> 1, 3
            long left_child_index = 2 * smallest_index + 1;
            // 2, 4
            long right_child_index = 2 * smallest_index + 2;
            long swap_count = 0;
            while (left_child_index < array_length && right_child_index < array_length && (array[smallest_index] > array[right_child_index] || array[smallest_index] > array[left_child_index]))
            {
                if (Math.Min(array[left_child_index], array[right_child_index]) == array[left_child_index])
                {
                    Swap(ref array[smallest_index], ref array[left_child_index]);
                    res.Add(Tuple.Create(smallest_index, left_child_index));
                    smallest_index = left_child_index;
                }
                else
                {
                    Swap(ref array[smallest_index], ref array[right_child_index]);
                    res.Add(Tuple.Create(smallest_index, right_child_index));
                    smallest_index = right_child_index;
                }
                swap_count++;
                left_child_index = 2 * smallest_index + 1;
                right_child_index = 2 * smallest_index + 2;
            }
            if (left_child_index < array_length && array[smallest_index] > array[left_child_index])
            {
                Swap(ref array[smallest_index], ref array[left_child_index]);
                res.Add(Tuple.Create(smallest_index, left_child_index));
                swap_count++;
            }
        }
        public Tuple<long, long>[] Solve(long[] array)
        {
            long startIndex = array.Length / 2 - 1;
            List<Tuple<long, long>> res = new List<Tuple<long, long>>();

            for (long i = startIndex; i >= 0; i--)
            {
                HeapifyTree(array, i, res);
            }

            return res.ToArray();
        }
}