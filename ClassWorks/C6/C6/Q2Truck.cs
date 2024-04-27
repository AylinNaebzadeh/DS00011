using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C6
{
    public class Q2Truck : Processor
    {
        public Q2Truck(string testDataName) : base(testDataName)
        { }

        public override string Process(string inStr) => C6Processors.ProcessQ2Truck(inStr, Solve);
        

        public long Solve(long n ,long[] petr ,long[] dist)
        {
            if (petr.Sum() < dist.Sum())
            {
                return -1;
            }
            long supply = 0;
            long min = 0;
            long minIndex = 0;
            for (long i = 0; i < n; i++)
            {
                supply += petr[i];
                supply -= dist[i];
                if (supply < min)
                {
                    min = supply;
                    minIndex = i + 1;
                }
            }
            return minIndex;
        }
    }
}
