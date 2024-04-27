using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q4LCSOfTwo : Processor
    {
        public Q4LCSOfTwo(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long[], long[], long>)Solve);

        public long Solve(long[] seq1, long[] seq2)
        {
            long seq1_length = seq1.Length;
            long seq2_length = seq2.Length;

            long[,] DP = new long[seq1_length + 2, seq2_length + 2];

            for (long i = 1; i < seq1_length + 1; i++)
            {
                for (long j = 1; j < seq2_length + 1; j++)
                {
                    if (seq1[i - 1] == seq2[j - 1])
                    {
                        DP[i, j] = 1 + DP[i - 1, j - 1];
                    }
                    else
                    {
                        long up = DP[i, j - 1];
                        long left = DP[i - 1, j];
                        DP[i, j] = Math.Max(up, left);
                    }
                }
            }

            return DP[seq1_length, seq2_length];
        }
    }
}
