using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class A4_4
{
        static long MaximumAdvertisementRevenue(int[] a, int[] b)
        {
            long res = 0;
            for (int i = 0; i < a.Length; i++)
            {
                for (int j = i + 1; j < a.Length; j++)
                {
                    if (a[i] < a[j])
                    {
                        int tmp = a[i];
                        a[i] = a[j];
                        a[j] = tmp;
                    }
                }
            }

            for (int i = 0; i < b.Length; i++)
            {
                for (int j = i + 1; j < b.Length; j++)
                {
                    if (b[i] < b[j])
                    {
                        int tmp = b[i];
                        b[i] = b[j];
                        b[j] = tmp;
                    }
                }
            }

            for (int i = 0; i < a.Length; i++)
            {
                res += Convert.ToInt64(a[i]) * Convert.ToInt64(b[i]);
            }
            return res;
        }
}