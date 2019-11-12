using System;
using System.Collections.Generic;
using System.Linq;
public static class Sieve
{
    public static int[] Primes(int limit)
    {
        if (limit < 2)
            throw new ArgumentOutOfRangeException("*** number must be greater than 1 ***");

        List<int> primes = new List<int>();
        primes = limit == 2 ? Enumerable.Range(2, 1).ToList() : Enumerable.Range(2, limit - 1).ToList();
        
        for (int i = 0; i < primes.Count; ++i)
        {
            // save the number in the current array position
            int current = primes[i];

            // loop through the multiples and remove if they're on the list
            for (int multiple = 2; multiple * current <= limit; multiple++)
            {
                primes.Remove(multiple * current);
            }
        }
            return primes.ToArray();
    }
}