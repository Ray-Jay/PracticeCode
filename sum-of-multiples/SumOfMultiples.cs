//  Date: 10-22-19
//  Exercism Sum of Multiples
//  Purpose: Given a number, find the sum of all the unique multiples of particular numbers up to
//  but not including that number.

//  UPGRADES: See if can accomplish this without casting to int[]
//  UPGRADES: See if can accomplish this without nested loops

using System;
using System.Collections.Generic;
using System.Linq;

public static class SumOfMultiples
{
    public static int Sum(IEnumerable<int> multiples, int max)
    {
        // declare variables
        int[] multiplesArray = new int[] { };
        int minArrValue = 0;
        HashSet<int> myHash = new HashSet<int>();

        if (multiples.Count() > 0)
        {
            multiplesArray = (int[])multiples;
            minArrValue = multiplesArray.Min();
        }

        // if max number is bigger than the minimum number in array (and not zero) add multiples to HashSet
        if (max > minArrValue)
        {
            foreach (int num in multiplesArray)
            {
                int count = 1;
                while (num != 0 && count * num < max)
                {
                    myHash.Add(count * num);        // since using HashSet, only unique multiples will be added
                    count++;
                }
            }
        }

        //// another solution from exercism
        //var set = new HashSet<int>();
        //foreach (var mul in multiples)
        //{
        //    for (int i = 1; i < max; i++)
        //    {
        //        int tmp = mul * i;
        //        if (tmp < max)
        //        {
        //            set.Add(tmp);
        //        }
        //    }
        //}

        return myHash.Sum();
    }
}