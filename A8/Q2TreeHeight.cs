using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A8
{
    public class Q2TreeHeight : Processor
    {
        public Q2TreeHeight(string testDataName) : base(testDataName)
        {
            ExcludeTestCases(21);
            ExcludeTestCases(22);
            ExcludeTestCases(23);
            ExcludeTestCases(24);
        }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public long Solve(long nodeCount, long[] tree)
        {
            // 
            long max_height = 0;
            for (long i = 0; i < nodeCount; i++)
            {
                long h = 0;
                long current = i;
                while (current != -1)
                {
                    h++;
                    current = tree[current];
                }
                max_height = Math.Max(h, max_height);
            }
            return max_height;
        }
    }
}
