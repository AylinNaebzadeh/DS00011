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