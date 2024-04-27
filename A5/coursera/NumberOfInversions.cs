class NumberOfInversions
{
    public static Tuple<long[], long> MergeForCountingInversions(long[] B,long[] C)
    {
        Array.Sort(B);Array.Sort(C);long number_of_pairs = 0;
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
                number_of_pairs += B.Length - i;
                D[k] = c;
                k++;
                j++;
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
        var x = MergeSort(b, 0, b.Length - 1);
        var y = MergeSort(c, 0, c.Length - 1);
        var z = MergeForCountingInversions(b, c);
        return new Tuple<long[], long>(z.Item1, x.Item2 + y.Item2 + z.Item2);
    }
}