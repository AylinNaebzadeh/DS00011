using System;
using TestCommon;

namespace E1
{
    public class Q3TeamSeas : Processor
    {
        public Q3TeamSeas(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E1Processors.ProcessQ3TeamSeas(inStr, Solve);

        public long Solve(long n, long m, long[] g, long[] c, long[] b, long[] p, long[] s)
        {
            throw new NotImplementedException();
        }
    }
}
