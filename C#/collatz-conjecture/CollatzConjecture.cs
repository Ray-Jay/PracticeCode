using System;
using System.Collections.Generic;

public static class CollatzConjecture
{
    public static int Steps(int number)
    {
        if (number < 1)
            throw new ArgumentException(" *** Invalid number. Must use positive integer *** ");

        List<int> list = new List<int>();

        // if number > 1, add it to the list, check if even or odd, apply appropriate formula 
        // to alter the number. keep going until you get to 1
        while (number > 1)
        {
            list.Add(number);
            //number = condition     ?  yes      : no
            number = number % 2 == 0 ? number / 2: number * 3 + 1;

            // if didn't use ternary, the below code would also work
            //if ( number % 2 == 0 )
            //{
            //    number = number / 2;
            //}
            //else
            //{
            //    number = number * 3 + 1;
            //}
        }
        return list.Count;
    }
}