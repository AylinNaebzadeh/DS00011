class LCS3
{
    public static long Solve(long[] seq1, long[] seq2, long[] seq3)
    {
        long seq1_length = seq1.Length;
        long seq2_length = seq2.Length;
        long seq3_length = seq3.Length;

        long[,,] DP = new long[seq1_length + 2, seq2_length + 2, seq3_length + 2];
        // i 0 --> seq1.length

        for (long i = 1; i < seq1_length + 1; i++)
        {
            for (long j = 1; j < seq2_length + 1; j++)
            {
                for (long k = 1; k < seq3_length + 1; k++)
                {
                    // har 3 ba ham mosavi bodan --> i-1, j - 1, k-1
                    // max(i-1, j, k| i, j, k-1| i, j-1 ,k)
                    if (seq1[i - 1] == seq2[j - 1] && seq2[j - 1] == seq3[k - 1])
                    {
                        DP[i, j, k] = 1 + DP[i - 1, j - 1, k - 1];
                    }
                    else
                    {
                        DP[i, j, k] = Math.Max(DP[i - 1, j, k], Math.Max(DP[i, j, k - 1], DP[i, j - 1, k]));
                    }
                }
            }
        }
        return DP[seq1_length, seq2_length, seq3_length];
    }
}