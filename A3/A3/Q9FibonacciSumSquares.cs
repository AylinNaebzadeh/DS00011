using System;
using TestCommon;

namespace A3
{
    public class Q9FibonacciSumSquares : Processor
    {
        public Q9FibonacciSumSquares(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long>)Solve);

        static long FibbonachiLastDigitAgain(long num , long m)
        {
            long[] Fib = new long[num + 1];
            if( num == 0)
                return 0;
            else if( num == 1)
                return 1;

            Fib[0] = 0;
            Fib[1] = 1;
            for(long i=2; i<=num; i++)
                Fib[i] = (Fib[i-1] + Fib[i-2]) % m;
            return Fib[num];
        }

        static long FibonacciAgain(long n, long m)
        {
            if ( n <= 1)
                return n;
            long previous = 0;
            long current = 1;
            long newnumber = 1;
            int pisano_length = 1;
            // 01120221
            while(true)
            {
                newnumber = (previous + current) % m;
                previous = current;
                current = newnumber;
                if(previous == 0 && newnumber == 1)
                    break;

                pisano_length += 1;
            }
            n = n % pisano_length;
            return FibbonachiLastDigitAgain(n , m);
        }
        public long Solve(long n)
            => (FibonacciAgain(n,10) * FibonacciAgain(n + 1,10))% 10;
    }
}
