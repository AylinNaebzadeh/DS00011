using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A6
{
    public class Q3EditDistance : Processor
    {
        public Q3EditDistance(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);

        public long Solve(string str1, string str2)
        {
            long str1_length = str1.Length;
            long str2_length = str2.Length;

            long[,] DP = new long[str1_length + 1, str2_length + 1];
            // DP[x, y] --> x --> number of rows
                        //  y --> number of columns

            for (long j = 0; j <= str2_length; j++)
            {
                DP[0, j] = j;
            }

            for (long i = 0; i <= str1_length; i++)
            {
                DP[i, 0] = i;
            }

            for (long i = 1; i < str1_length + 1; i++)
            {
                for (long j = 1; j < str2_length + 1; j++)
                {
                    long insertion = DP[i, j - 1] + 1;
                    long deletion = DP[i - 1, j] + 1;
                    long match = DP[i - 1, j - 1];
                    long mismatch = DP[i - 1, j - 1] + 1;
                    if(str1[(int)i - 1] == str2[(int)j - 1])
                    {
                        DP[i, j] = Math.Min(insertion, Math.Min(deletion, match));
                    }
                    else
                    {
                        DP[i, j] = Math.Min(insertion, Math.Min(deletion, mismatch));
                    }
                }
            }
            return DP[str1_length, str2_length];
        }
    }
}
