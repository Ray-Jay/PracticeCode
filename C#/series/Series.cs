using System;
using System.Collections.Generic;

public static class Series
{
    public static string[] Slices(string numbers, int sliceLength)
    {
        if (sliceLength > numbers.Length || sliceLength <= 0 || numbers.Length == 0)
        {
            throw new ArgumentException("** Length requested larger than input **");
        }

        List<string> result = new List<string>();
        for (int i = 0; i < numbers.Length; i++)
        {
            if (i + sliceLength <= numbers.Length)
            {
                result.Add(numbers.Substring(i, sliceLength));
            }
        }

        return result.ToArray();
    }
}