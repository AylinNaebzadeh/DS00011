using System;
using System.Collections.Generic;
using System.Linq;
using TestCommon;

namespace C1
{
    public class Q1 : Processor
    {
        public Q1(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long n = first[0];
            long x = first[1];
            long [] a = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(n, a, x).ToString();
        }

        public long Solve(long n, long[] a, long x)
        {
            var mylist = a.OrderBy(x => x).ToList();
            while(!(mylist.Sum() / mylist.Count() >= x))
            {
                mylist.Remove(mylist.FirstOrDefault());
                if(mylist.Count() == 0)
                {
                    break;
                }
            }
            return mylist.Count();
        }
    }
}
