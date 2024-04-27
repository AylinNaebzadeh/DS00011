using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q5MaximizeNumberOfPrizePlaces : Processor
    {
        public Q5MaximizeNumberOfPrizePlaces(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[]>) Solve);


        public virtual long[] Solve(long n)
        {
            var ans = new List<long>();
            long sum = 0;
            long tmp = n;

            for (long i = n - 1; i >= 0; i--)
            {
                n = tmp - i;
                sum += n;
                if( sum >= tmp)
                {
                    break;
                }
                ans.Add(n);
            }

            long total = ans.Sum(s => Convert.ToInt64(s));
            if (total == tmp)
            {
                return ans.ToArray();
            }

            long rem = tmp - total;
            if (ans.Contains(rem))
            {
                ans.Remove(ans.LastOrDefault());
                ans.Add(tmp - ans.Sum(ss => Convert.ToInt64(ss)));
            }
            else
            {
                ans.Add(rem);
            }
            return ans.ToArray();
        }
    }
}

