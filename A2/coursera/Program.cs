using System;

namespace coursera
{
    class Program
    {
        // public static int sum(int a ,int b) => a + b;
        public static long FindMaxPairProduct(long[] myarray)
        {
            long result = 0;
            for(int i=0; i<myarray.Length ; i++)
            {
                for(int j=i+1; j<myarray.Length; j++)
                {
                    if(result < myarray[i] * myarray[j])
                        result = myarray[i] * myarray[j];
                }
            }
            return result;
        }

        public static long FindMaxPairProductFaster(long[] myarray)
        {
            if(myarray.Length == 2)
            {
                return myarray[0] * myarray[1];
            }
            else {
            int max_index=0;
            for(int i=0; i<myarray.Length; i++)
                if( myarray[i] > myarray[max_index])
                    max_index = i;
            int max_indexx=0 ;
            for(int j=0; j<myarray.Length; j++)
                if(myarray[j] > myarray[max_indexx])
                    if(j != max_index)
                        max_indexx = j;
            
                checked
                {
                    return myarray[max_index] * myarray[max_indexx];
                }
            }
        }
        static void Main(string[] args)
        {
            // string x  = Console.ReadLine();
            // int y = int.Parse(x.Split(' ')[0]);
            // int z = int.Parse(x.Split(' ')[1]);
            // System.Console.WriteLine(sum(y , z));

            int size = Convert.ToInt32(Console.ReadLine());
            long[] newarray = new long[size];
            checked
            {
                newarray = Array.ConvertAll(Console.ReadLine().Trim().Split(' '),Convert.ToInt64);
                // long[] newarray = {100000,90000};
                System.Console.WriteLine(FindMaxPairProductFaster(newarray));
            }
        }
    }
}
