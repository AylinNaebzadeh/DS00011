using System;
using TestCommon;

namespace A3
{
    public class Q6FibonacciMod : Processor
    {
        public Q6FibonacciMod(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);
        
        static long FibbonachiLastDigitAgain(long num , long m)
        {
            long[] Fib = new long[num + 1];
            if( num == 0)
                return 0;
            else if( num == 1)
                return 1;
            else {
                Fib[0] = 0;
                Fib[1] = 1;
                for(long i=2; i<=num; i++)
                    Fib[i] = (Fib[i-1] + Fib[i-2]) % m;
                return Fib[num];
            }
        }

        public long Solve(long a, long b)
        {
            if ( a <= 1)
                return a;
            

            long previous = 0;
            long current = 1;
            long newnumber = 1;

            int pisano_length = 1;

            // 01120221
            while(true)
            {
                newnumber = (previous + current) % b;
                previous = current;
                current = newnumber;
                if(previous == 0 && newnumber == 1)
                    break;
                pisano_length += 1;
            }

            a = a % pisano_length;
            return FibbonachiLastDigitAgain(a , b);
        }
    }
}
