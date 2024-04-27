using System;
using TestCommon;

namespace A3
{
    public class Q5LCM : Processor
    {
        public Q5LCM(string testDataName) : base(testDataName) { }

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long, long>)Solve);

        static long EuclideanGCD(long a , long b)
        {
            if ( b == 0)
                return a;
            long ra = a % b;
            return EuclideanGCD( b , ra);
        }
        public long Solve(long a, long b)
            => a * b / EuclideanGCD(a , b);

    }
}
