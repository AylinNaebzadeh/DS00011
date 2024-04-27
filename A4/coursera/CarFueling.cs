using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class A4_3
{
        static int CarRefill(int dist, int tank, int[] stops)
        {
            int numRefills = 0;
            int currentRefill = 0;
            int len = stops.Length;

            int[] newstops = new int[len + 2];

            for (int i = 1; i <= len; i++)
                newstops[i] = stops[i - 1];

            newstops[0] = 0;
            newstops[newstops.Length - 1] = dist;

            while (currentRefill <= newstops.Length - 2)
            {
                int lastRefill = currentRefill;
                while ((currentRefill <= (newstops.Length - 2)) && (newstops[currentRefill + 1] - newstops[lastRefill] <= tank))
                {
                    currentRefill++;
                }
                if (currentRefill == lastRefill)
                {
                    return -1;
                }
                if (currentRefill <= newstops.Length - 2)
                    numRefills++;
            }
            return numRefills;
        }
}