using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCommon;

namespace A2
{
    public class Q2FastMaxPairWise : Processor
    {

        public void Swap(ref long a,ref long b)
        {
            long tmp = a;
            a = b;
            b = tmp;
        }

        public void Sort(long[] A)
        {
            for (int i = 0; i < A.Length; i++)
            {
                for (int j = i+1; j < A.Length; j++)
                {
                    if (A[j] > A[i])
                    {
                        Swap(ref A[j] , ref A[i]);
                    }
                }
            }
        }
        public Q2FastMaxPairWise(string testDataName) : base(testDataName) { }
        public override string Process(string inStr) => 
            Solve(inStr.Split(new char[] { '\n', '\r', ' ' },
                StringSplitOptions.RemoveEmptyEntries)
                 .Select(s => long.Parse(s))
                 .ToArray()).ToString();

        public virtual long Solve(long[] numbers)
        {
            int index = 0;
            for (int i = 1; i < numbers.Length; i++)
            {
                if (numbers[i] > numbers[index])
                {
                    index = i;
                }
            }

            Swap(ref numbers[index], ref numbers[numbers.Length - 1]);

            index = 0;
            for (int i = 0; i < numbers.Length - 1; i++)
            {
                if (numbers[i] > numbers[index])
                {
                    index = i;
                }
            }

            Swap(ref numbers[index], ref numbers[numbers.Length - 2]);

            return numbers[numbers.Length - 1] * numbers[numbers.Length - 2];
        }
    }
}
