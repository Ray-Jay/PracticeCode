//  Date: 10-26-19
//  Exercism IO Grains
//  Purpose: Given square #'s 1-64, calculate amount on each square, if each square is double the square before (starts at 1)
using System;
using System.Linq;
using System.Numerics;

public static class Grains
{
    public static ulong Square(int n)
    {
        if (n < 1 || n > 64)
            throw new ArgumentOutOfRangeException("*** Must use integer 1 - 64 only ***");

        return (ulong)Math.Pow(2, n - 1);
    }

    public static ulong Total()
    {
        BigInteger sum = 0;
        for (int i = 0; i < 64; i++)
        {
            sum += BigInteger.Pow(2, i);
        }

        return (ulong)sum;
        //return (ulong)Enumerable.Range(0, 63).Select(BigInteger x => BigInteger.Pow(2, x)).Sum();
    }
}