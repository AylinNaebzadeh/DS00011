using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C5
{
    public class Q1Stairs : Processor
    {
        public Q1Stairs(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long n = first[0];
            long m = first[1];
            long[] p = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(n, m, p).ToString();
        }

        public long Solve(long n, long m, long[] p)
        {
            //n --> size of p --> 2
            //m --> the number of stairs which is 3
            long[] DP = new long[n+1];
            DP[0] = 1;
            DP[1] = 1;
            for (long i = 2; i <= n; i++)
            {
                for (long j = 0; j < m; j++)
                {
                    if (i - p[j] >= 1)
                    {
                        DP[i] += (DP[i - p[j]] % (long)(Math.Pow(10, 9) + 7)); 
                    }
                }
            }
            return DP[n] % (long)(Math.Pow(10, 9) + 7); 
        }
    }
}
