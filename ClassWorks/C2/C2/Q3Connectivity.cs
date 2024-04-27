using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace C2
{
    public class Q3Connectivity : Processor
    {
        public Q3Connectivity(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long n = first[0];
            long a = first[1];
            long b = first[2];
            long [] p = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(n, a, b, p).ToString();
        }

        public long Solve(long n, long a, long b, long[] p)
        {
            throw new NotImplementedException();
        }
    }
}
