using System;
using System.Collections.Generic;
using System.Linq;

public enum Classification
{
    Perfect,
    Abundant,
    Deficient
}

public static class PerfectNumbers
{
    public static Classification Classify(int number)
    {
        if (number < 1)
        throw new ArgumentOutOfRangeException("*** Must use integer 1 or larger ***");

        // calculcate sum of factor (without actual number). generate numbers 1 to n-1, if evenly divides, add it
        int aliquotSum = Enumerable.Range(1, number - 1).Where(x => number % x == 0).Select(x => x).Sum();

        // if sum equals number, it's perfect. if not, is sum less than original number. if so, it's deficient, else it's abundant
        return aliquotSum == number ? Classification.Perfect : aliquotSum < number ? Classification.Deficient : Classification.Abundant;
    }
}
