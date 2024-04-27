using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using TestCommon;

namespace C2
{
    public class Q1FlowerShop : Processor
    {
        public Q1FlowerShop(string testDataName) : base(testDataName)
        {}

        public override string Process(string inStr)
        {
            var lines = inStr.Split(new char[] { '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);
            var first = lines[0].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            long a = first[0];
            long b = first[1];
            long [] p = lines[1].Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(d => long.Parse(d)).ToArray();
            return Solve(a, b, p).ToString();
        }
        public static long Solve(long a, long b, long[] p)
        {
            // a --> tedad golha
            // b --> tedad moshtari ha
            
            int tmp = Convert.ToInt32(b);
            long sum = 0;
            long count = 1;
            var my_list = p.OrderByDescending(x => x).ToList();
            while(my_list.Count() != 0)
            {
                var new_list = new List<long>();
                for(int j = 0; j < b; j++)
                {
                    if(j > my_list.Count() - 1)
                    {
                        break;
                    }
                    new_list.Add(my_list[j] * count);
                }
                sum += new_list.Sum();
                count++;
                my_list.RemoveRange(0,new_list.Count);
                new_list.Clear();

            } 
            return sum;
        }
    }
}
