using System;
using TestCommon;

namespace A3
{
    public class Q2FibonacciFast : Processor
    {
        public Q2FibonacciFast(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        public long Solve(long n)
        {
            long[] Fib = new long[n + 1];
            if( n == 0)
                return 0;
            else if( n == 1)
                return 1;
            else {
                Fib[0] = 0;
                Fib[1] = 1;
                for(int i=2; i<=n; i++)
                    Fib[i] = Fib[i-1] + Fib[i-2];
                return Fib[n];
            }
        }
    }
}
