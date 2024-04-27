using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C8
{
    public class Q2Palindrome : Processor
    {
        public Q2Palindrome(string testDataName) : base(testDataName) {}

        public override string Process(string inStr) => C8Processors.ProcessQ2Palindrome(inStr, Solve);
        
        public long Solve(long n, long x, long k)
        {
            throw new NotImplementedException();
        }
    }
}