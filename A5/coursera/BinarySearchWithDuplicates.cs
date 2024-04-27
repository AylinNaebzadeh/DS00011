class BinarySearchWithDuplicates
{
    public static long BSearch(long[] a, long l, long h, long key)
    {
        if (h < l)
        {
            return -1;
        }
        long mid = ((l + h) / 2);
        long i = 0;
        if (key == a[mid])
        {
            for (i = 0; i <= mid; i++)
            {
                if (a[mid] == a[i])
                {
                    mid = i;
                    break;
                }
            }
            return mid; 
        }

        else if (key < a[mid])
        {
            return BSearch(a, l, mid - 1, key);
        } 

        else
        {
            return BSearch(a, mid + 1, h, key);
        }
    }
}