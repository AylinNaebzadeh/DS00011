static long EuclideanGCD(long a , long b)
{
    if ( b == 0)
        return a;
    long ra = a % b;
    return EuclideanGCD( b , ra);
}

static long EuclideanLCM(long a ,long b)
    => a * b / EuclideanGCD(a , b);