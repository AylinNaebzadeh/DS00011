using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
// using Priority_Queue;
using TestCommon;

namespace C9
{
    public class Q2Snakes : Processor
    {
        public Q2Snakes(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C7Processors.ProcessQ2Snakes(inStr, Solve);
        

        public long Solve(long n,long[][] ladders, long m,long[][] snakes)
        {
            return -1;
        }
    }
}
