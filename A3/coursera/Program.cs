using System;

namespace coursera
{
    class Program
    {
        // static long ComputeLastDigit(long num)
        //     => FibbonachFast(num) % 10;

        static long FibbonachFast(long num)
        {
            long[] Fib = new long[num + 1];
            if( num == 0)
                return 0;
            else if( num == 1)
                return 1;
            else {
                Fib[0] = 0;
                Fib[1] = 1;
                for(int i=2; i<=num; i++)
                    Fib[i] = Fib[i-1] + Fib[i-2];
                return Fib[num];
            }
        }

        static ulong FibbonachiLastDigit(ulong num)
        {
            checked{
                ulong[] Fib = new ulong[num + 1];
                if( num == 0)
                    return 0;
                else if( num == 1)
                    return 1;
                else {
                    Fib[0] = 0;
                    Fib[1] = 1;
                    for(ulong i=2; i<=num; i++)
                        Fib[i] = (Fib[i-1] + Fib[i-2]) % 10;
                    return Fib[num];
                }
            }
        }

        static long EuclideanGCD(long a , long b)
        {
            if ( b == 0)
                return a;
            long ra = a % b;
            return EuclideanGCD( b , ra);
        }

        static long EuclideanLCM(long a ,long b)
            => a * b / EuclideanGCD(a , b);


        static long FibbonachiLastDigitAgain(long num , long m)
        {
            long[] Fib = new long[num + 1];
            if( num == 0)
                return 0;
            else if( num == 1)
                return 1;
            else {
                Fib[0] = 0;
                Fib[1] = 1;
                for(long i=2; i<=num; i++)
                    Fib[i] = (Fib[i-1] + Fib[i-2]) % m;
                return Fib[num];
            }
        }

        // static ulong FibbonachiLastDigitTryCatch(ulong num)
        // {
        //     checked{
        //         try{
        //             long[] Fib = new long[num + 1];
        //             if( num == 0)
        //                 return 0;
        //             else if( num == 1)
        //                 return 1;
        //             else {
        //                 Fib[0] = 0;
        //                 Fib[1] = 1;
        //                 for(long i=2; i<=num; i++)
        //                     Fib[i] = (Fib[i-1] + Fib[i-2]) % 10;
        //                 return Fib[num];
        //             }
        //     }
        // }
        static long FibonacciAgain(long n, long m)
        {
            if ( n <= 1)
                return n;
            

            long previous = 0;
            long current = 1;
            long newnumber = 1;

            int pisano_length = 1;

            // 01120221
            while(true)
            {
                newnumber = (previous + current) % m;
                previous = current;
                current = newnumber;
                if(previous == 0 && newnumber == 1)
                    break;

                pisano_length += 1;
            }

            n = n % pisano_length;
            return FibbonachiLastDigitAgain(n , m);
        }

        // static int FibbonachiSumLastDigitSlow(long n)
        // {
        //     int sum = 0;
        //     for(long i=0; i<n+1; i++)
        //     {
        //         sum += FibbonachiLastDigit(i);
        //     }
        //     return sum % 10;
        // }

        static long FibbonachiSumLastDigitFast(long n)
        {
            long res = FibonacciAgain(n + 2 , 10) - 1;
            if (res>= 0)
                return res;
            return res + 10;
        }
        static long FibbonachiSumLastDigitFastAgain(long n , long m)
        {
            long res = FibonacciAgain(m + 2 , 10) -FibonacciAgain(n + 1 , 10);
            if (res>= 0)
                return res;
            return res + 10;
        }

        static long FibbonachiSquareSumLastDigitFast(long n)
            => (FibonacciAgain(n,10) * FibonacciAgain(n + 1,10))% 10;


        static void Main(string[] args)
        {
            // int n = Convert.ToInt32(Console.ReadLine());
            // System.Console.WriteLine(FibbonachiLastDigit(n));

            // int[] gcdnums = new int[2];
            // gcdnums = Array.ConvertAll(Console.ReadLine().Trim().Split(' '),Convert.ToInt32);

            // System.Console.WriteLine(EuclideanLCM(gcdnums[0],gcdnums[1]));

            // long[] fibonacciagain = new long[2];
            // fibonacciagain = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt64);
            // System.Console.WriteLine(FibonacciAgain(fibonacciagain[0] ,fibonacciagain[1]));

            // long n = Convert.ToInt64(Console.ReadLine());
            // System.Console.WriteLine(FibbonachiSumLastDigitFast(n));

            // long[] fibonaccisumagain = new long[2];
            // fibonaccisumagain = Array.ConvertAll(Console.ReadLine().Trim().Split(' '), Convert.ToInt64);
            // System.Console.WriteLine(FibbonachiSumLastDigitFastAgain(fibonaccisumagain[0] ,fibonaccisumagain[1]));

            long n = Convert.ToInt64(Console.ReadLine());
            System.Console.WriteLine(FibbonachiSquareSumLastDigitFast(n));
        }
    }
}
