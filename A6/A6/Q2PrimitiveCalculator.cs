using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A6
{
    public class Q2PrimitiveCalculator : Processor
    {
        public Q2PrimitiveCalculator(string testDataName) : base(testDataName) { }
        
        public override string Process(string inStr) => 
            TestTools.Process(inStr, (Func<long, long[]>) Solve);

        private static List<long> RemainderGenerator(long n, long divisor)
        {
            List<long> remainders = new List<long>();
            for (long i = n - n % divisor; i < n + 1; i++)
            {
                remainders.Add(i);
            }
            return remainders;
        }

        public static long[] Solve(long n)
        {
            long[] dp_operations_count = new long[n + 1];
            dp_operations_count[0] = 0;
            dp_operations_count[1] = 0;
            dp_operations_count[2] = 1;
            long[][] dp_sequences = new long[n + 1][];
            dp_sequences[0] = new long[]{0};
            dp_sequences[1] = new long[]{1};
            dp_sequences[2] = new long[]{1, 2};
            for (long i = 3; i <= n; i++)
            {
                long q_3 = dp_operations_count[i / 3] + i % 3 + 1;
                long q_2 = dp_operations_count[i / 2] + i % 2 + 1;
                dp_operations_count[i] = Math.Min(q_3, q_2);

                if (q_3 < q_2 || i % 3 == 0)
                {
                    var remainders = RemainderGenerator(i, 3);
                    dp_sequences[i] = dp_sequences[i / 3].ToList().Concat(remainders).ToArray();
                }
                else
                {
                    var remainders = RemainderGenerator(i, 2);
                    dp_sequences[i] = dp_sequences[i / 2].ToList().Concat(remainders).ToArray();
                }
            }
            return dp_sequences[n];
        }
    }
}
