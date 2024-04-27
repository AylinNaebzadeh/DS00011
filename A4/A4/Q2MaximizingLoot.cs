using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q2MaximizingLoot : Processor
    {
        public Q2MaximizingLoot(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], long[], long>) Solve);


        public virtual long Solve(long capacity, long[] weights, long[] values)
        {
            double c = Convert.ToDouble(capacity);
            double value = 0;
            var mylist = weights.Zip(values, (w,v) => new Tuple<double, double>(w, (double)v/(double)w)).ToList();
            var SortedValues = mylist.OrderByDescending(p => p.Item2);
            double Max = SortedValues.FirstOrDefault().Item2;
            double a = 0.0;
            double wi = 0;
            foreach (Tuple<double, double> kvp in SortedValues)
            {
                if (c == 0)
                {
                    return Convert.ToInt64(value);
                }

                wi = kvp.Item1;
                a = Math.Min(wi, c);
                value += a * kvp.Item2;
                wi -= a;

                c -= a;
            }
            return Convert.ToInt64(value);
        }


        public override Action<string, string> Verifier { get; set; } =
            TestTools.ApproximateLongVerifier;

    }
}
