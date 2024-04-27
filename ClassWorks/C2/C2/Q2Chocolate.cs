
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C2
{
    public class Q2Chocolate : Processor
    {
        public Q2Chocolate(string testDataName) : base(testDataName)
        {
        }

        public override string Process(string inStr) => TestTools.Process(inStr, (Func<long, long[], long>)Solve);

        public static long Solve(long n, long[] a)
        {
            var A = new long[a.Count()];
            for (int i = 0; i < a.Count(); i++)
            {
                A[i] = 1;
            }

            for (int i = 0; i < a.Count(); i++)
            {
                if (i+1 > a.Count() - 1)
                {
                    break;
                }

                if(a[i+1] > a[i])
                {
                    A[i+1] = A[i] + 1;
                }
            }

            for (int i =  A.Count() - 1; i >=0; i--)
            {
                if (i-1 < 0)
                {
                    break;
                }
                if(a[i-1] > a[i] && A[i-1] <= A[i])
                {
                    A[i-1] = A[i] + 1;
                }
            }
            return A.Sum();
        }
    }
}
