using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class A4_7
{
        static bool IsGreaterOrEqual(string s1, string s2)
        {
            if (string.Compare(s1 + s2, s2 + s1) == 1)
            {
                return true;
            }
            return false;
        }

        static string LargestNumber(string[] digits)
        {
            List<string> Digits = digits.ToList();
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