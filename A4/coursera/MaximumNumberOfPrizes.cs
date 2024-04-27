using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class A4_6
{
        static List<long> MaximumNumberOfPrizes(long n)
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
                return ans;
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
            return ans;
        }
}