using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C5
{
    public class Q2LCS : Processor
    {
        public Q2LCS(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<string, string, long>)Solve);


        public static long Solve(string a, string b)
        {
            // a --> aa
            // b --> baaa
            long a_length = a.Length;
            long b_length = b.Length;
            long count = 0;

            long[,] DP1 = new long[a_length + 2, b_length + 2];
            long[,] DP2 = new long[a_length + 2, b_length + 2];

            for (int i = 1; i < a_length + 1; i++)
            {
                for (int j = 1; j < b_length + 1; j++)
                {
                    if (a[i - 1] == b[j - 1])
                    {
                        DP1[i, j] = 1 + DP1[i - 1, j - 1];
                    }
                    else
                    {
                        long up = DP1[i, j - 1];
                        long left = DP1[i - 1, j];
                        DP1[i, j] = Math.Max(up, left);
                    }
                }
            }

            long LCS1 = DP1[a_length, b_length];

            for (int i = (int)a_length; i >= 1; i--)
            {
                for (int j = (int)b_length; j >= 1; j--)
                {
                    if ((a[i-1] == b[j- 1]))
                    {
                        DP2[i, j] = 1 + DP2[i + 1, j + 1];
                    }
                    else
                    {
                        long down = DP2[i, j + 1];
                        long right = DP2[i + 1, j];
                        DP2[i, j] = Math.Max(down, right);
                    }
                }
            }

            for (int i = 0; i < a_length + 1; i++)
            {
                char[] res = new char[b_length];
                for (int j = 1; j < b_length + 1; j++)
                {
                    if (DP1[i, j - 1] + DP2[i+1, j + 1] == LCS1 && !Array.Exists(res, e => e == b[j-1]))
                    {
                        res[j - 1] = b[j - 1];
                        count++;
                    }
                }
            }
            return count;
        }
    }
}
