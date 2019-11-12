//  Date: 10-25-19
//  Exercism IO Difference of Squares
//  Purpose: Finds the square of a sum, sum of squares, and the difference between the two

using System;
using System.Linq;

public static class DifferenceOfSquares
{
    // uses formula to calculate 
    public static int CalculateSquareOfSum(int max)
    {
        return (int)Math.Pow((max * (1 + max)) / 2, 2);
    }

    // uses LINQ to generate numbers, square them, then add them
    public static int CalculateSumOfSquares(int max)
    {
        return Enumerable.Range(1, max).Select(x => x * x).Sum();
    }

    public static int CalculateDifferenceOfSquares(int max)
    {
        return CalculateSquareOfSum(max) - CalculateSumOfSquares(max);
    }
}