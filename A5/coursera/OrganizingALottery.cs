class OrganizingLottery
{
    private static long BinarySearchInStarts(long[] a, long l, long h, long key)
    {
        if (h < l)
        {
            return h;
        }
        long mid = (l + h) / 2;
        if (key == a[mid])
        {
            while(mid + 1 < a.Length && a[mid+1] == key)
            {
                mid++;
            }
            return mid;
        }
        else if (key < a[mid])
        {
            return BinarySearchInStarts(a, l, mid - 1, key);
        }
        else
        {
            return BinarySearchInStarts(a, mid + 1, h, key);
        }
    }
    private static long BinarySearchInEnds(long[] a, long l, long h, long key)
    {
        if (h < l)
        {
            return l;
        }
        long mid = (l + h) / 2;
        if (key == a[mid])
        {
            while(mid - 1 > -1 && a[mid-1] == key)
            {
                mid--;
            }
            return mid;
        }
        else if (key < a[mid])
        {
            return BinarySearchInEnds(a, l, mid - 1, key);
        }
        else
        {
            return BinarySearchInEnds(a, mid + 1, h, key);
        }
    }
    public virtual long[] Solve(long[] points, long[] startSegments, long[] endSegment)
    {
        long s_length = startSegments.Length;
        Array.Sort(startSegments);
        Array.Sort(endSegment);
        long p_length = points.Count();
        long[] res = new long[p_length];
        long count = 0;
        for (long i = 0; i < p_length; i++)
        {
            // if (points[i] < startSegments.Min() || points[i] > endSegment.Max())
            // {
            //     count = 0;
            //     continue;
            // }
            long index_in_s = BinarySearchInStarts(startSegments, 0, s_length - 1, points[i]);
            long index_in_e = BinarySearchInEnds(endSegment, 0, s_length - 1, points[i]);
            count = index_in_s - index_in_e + 1;
            res[i] = count; 
        }
        return res;
    }
}