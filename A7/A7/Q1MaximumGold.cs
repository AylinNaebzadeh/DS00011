using System;
using System.Collections.Generic;
using System.Text;
using TestCommon;

namespace A7
{
    public class Q1MaximumGold : Processor
    {
        public Q1MaximumGold(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long W, long[] goldBars)
        {
            long goldBars_count = goldBars.Length;
            long[,] dp_value = new long[W + 1, goldBars_count + 1];
            for (long i = 0; i <= W; i++)
            {
                dp_value[i, 0] = 0;
            }

            for (long j = 0; j <= goldBars_count; j++)
            {
                dp_value[0, j] = 0;
            }

            for (long i = 1; i < W + 1; i++)
            {
                for (long j = 1; j < goldBars_count + 1; j++)
                {
                    dp_value[i, j] = dp_value[i, j - 1];
                    if (goldBars[j - 1] <= i)
                    {
                        long val = dp_value[i - goldBars[j - 1], j - 1] + goldBars[j - 1];
                        if (dp_value[i, j] < val)
                        {
                            dp_value[i, j] = val;
                        }
                    }
                }
            }
            
            return dp_value[W, goldBars_count];
        }
    }
}
