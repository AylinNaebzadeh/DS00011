using System;
using System.Linq;

namespace C1
{
    class Program
    {
        public static long Solve(long n, long[] a, long x)
        {
            var mylist = a.OrderBy(x => x).ToList();
            while(!(a.Sum() / mylist.Count() >= x))
            {
                mylist.Remove(mylist.FirstOrDefault());
            }
            return mylist.Count();
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
            var myarray = new long[]{1 ,1 ,1,5};
            System.Console.WriteLine(Solve(4,myarray, 2));
        }
    }
}
