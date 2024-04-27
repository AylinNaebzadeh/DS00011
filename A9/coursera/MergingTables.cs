class MergingTables
{
        public static long[] Solve(long[] tableSizes, long[] targetTables, long[] sourceTables)
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
}