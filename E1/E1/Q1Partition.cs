using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace E1
{
    public class Q1Partition : Processor
    {
        public Q1Partition(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => E1Processors.ProcessQ1Partition(inStr, Solve);

        public long Solve(long n, long x, long[] p)
        {
            long count = 0;
            Array.Sort(p);
            

            var my_list = new List<long>();
            my_list.Add(p[0]);
            for (long i = 0; i < p.Length; i++)
            {
                if (i + 1 >= p.Length)
                {
                    break;
                }
                else if (p[i + 1] - my_list.Min() <= x)
                {
                    my_list.Add(p[i + 1]);
                }
                else
                {
                    count++;
                    my_list.Clear();
                    my_list.Add(p[i + 1]);
                }
            }
            return count + 1;
        }
    }
}
