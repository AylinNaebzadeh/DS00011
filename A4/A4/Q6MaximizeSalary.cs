using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TestCommon;

namespace A4
{
    public class Q6MaximizeSalary : Processor
    {
        public Q6MaximizeSalary(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr) =>
            TestTools.Process(inStr, (Func<long, long[], string>) Solve);

        private static bool IsGreaterOrEqual(string s1, string s2)
        {
            if (string.Compare(s1 + s2, s2 + s1) == 1)
            {
                return true;
            }
            return false;
        }
        public virtual string Solve(long n, long[] numbers)
        {
            var myArray = Array.ConvertAll(numbers, x => x.ToString());
            List<string> Digits = myArray.ToList();
            var answer = new List<string>();
            while (Digits.Count != 0)
            {
                // try StringBuilder
                var MaxDigit = new StringBuilder(" ", Digits.Count);
                var Max = MaxDigit.ToString();
                foreach (var d in Digits)
                {
                    if (IsGreaterOrEqual(d, Max))
                    {
                        Max = d;
                    }
                }
                answer.Add(Max);
                Digits.Remove(Max);
            }
            string s = string.Join("", answer);
            return s;
        }
    }
}

