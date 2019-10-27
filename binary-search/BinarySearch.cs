using System;

public static class BinarySearch
{
    public static int Find(int[] input, int value)
    {
        int beginIndex = 0;
        int midIndex = 0;
        int lastIndex = input.Length - 1;

        while (beginIndex <= lastIndex)
        {
            midIndex = (beginIndex + lastIndex) / 2;
            if (input[midIndex] < value)
            {
                beginIndex = midIndex + 1;
            }
            else if (input[midIndex] > value)
            {
                lastIndex = midIndex - 1;
            }
            else    // value found
            {
                return midIndex;
            }
        }

        return -1;
    }
}