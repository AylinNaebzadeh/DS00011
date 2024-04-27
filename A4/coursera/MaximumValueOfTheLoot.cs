using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class A4_2
{
        static double KnapsackLINQ(double capacity, double[] weights, double[] values)
        {
            double value = 0.0;
            var mylist = weights.Zip(values, (w,v) => new Tuple<double, double>(w, v/w)).ToList();
            var SortedValues = mylist.OrderByDescending(p => p.Item2);
            double Max = SortedValues.FirstOrDefault().Item2;
            double a = 0;
            double wi = 0.0;
            foreach (Tuple<double, double> kvp in SortedValues)
            {
                if (capacity == 0)
                {
                    return value;
                }

                wi = kvp.Item1;
                a = Math.Min(wi, capacity);
                value += a * kvp.Item2;
                wi -= a;

                capacity -= a;
            }
            return value;
        }
}