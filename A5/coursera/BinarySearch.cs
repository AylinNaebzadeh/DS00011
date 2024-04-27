class BinarySearch
{
    private static long BinarySearch(long[] a, long l, long h, long key)
    {
        if (h < l)
        {
            return -1;
        }
        long mid = (l + h) / 2;
        if (key == a[mid])
        {
            return mid;
        }
        else if (key < a[mid])
        {
            return BinarySearch(a, l, mid - 1, key);
        }
        else
        {
            return BinarySearch(a, mid + 1, h, key);
        }
    }
}