using System;
using System.Diagnostics;

public static class RealNumberExtension
{
    public static double Expreal(this int realNumber, RationalNumber r)
    {
        double num = r.Numerator * 1.0;
        return Math.Round(Math.Pow(realNumber, (double)r.Numerator / r.Denominator), 7);
    }

    // find and return greatest common divisor
    public static int FindGCD(this RationalNumber r)
    {
        int gcd = FindGCDrec(r.Numerator, r.Denominator);
        return Math.Abs(gcd);
    }

    // find and return greatest common divisor (recursive)
    private static int FindGCDrec(int numerator, int denominator)
    {
        return denominator == 0 ? numerator : FindGCDrec(denominator, numerator % denominator);
    }
}

public struct RationalNumber
{
    // properties
    public int Numerator { get; set; }
    public int Denominator { get; set; }

    // constructor
    public RationalNumber(int numerator, int denominator)
    {
        Numerator = numerator;
        Denominator = denominator;
    }

    // add two fractions and return reduced value
    public static RationalNumber operator +(RationalNumber r1, RationalNumber r2)
    {
        var rn = new RationalNumber(r1.Numerator * r2.Denominator + r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator);
        rn = rn.Reduce();
        return rn;
    }

    // subtract two fractions and return reduced value
    public static RationalNumber operator -(RationalNumber r1, RationalNumber r2)
    {
        var rn = new RationalNumber(r1.Numerator * r2.Denominator - r2.Numerator * r1.Denominator, r1.Denominator * r2.Denominator);
        rn = rn.Reduce();
        return rn;
    }

    // multiply two fractions and return reduced value
    public static RationalNumber operator *(RationalNumber r1, RationalNumber r2)
    {
        var rn = new RationalNumber(r1.Numerator * r2.Numerator, r1.Denominator * r2.Denominator);
        rn = rn.Reduce();
        return rn;
    }

    // divide two fractions and return reduced value
    public static RationalNumber operator /(RationalNumber r1, RationalNumber r2)
    {
        var rn = new RationalNumber(r1.Numerator * r2.Denominator, r1.Denominator * r2.Numerator);
        rn = rn.Reduce();
        return rn;
    }

    // find the absolute value and return the reduced number
    public RationalNumber Abs()
    {
        return new RationalNumber(Math.Abs(Numerator), Math.Abs(Denominator)).Reduce();
    }

    // reduce fraction to lowest terms
    public RationalNumber Reduce()
    {
        int gcd = this.FindGCD();
        Numerator /= gcd;
        Denominator /= gcd;
        if (Denominator < 0)
        {
            Numerator *= -1;
            Denominator *= -1;
        }
        return this;

    }

    // raises rational number to exponential power
    public RationalNumber Exprational(int power)
    {
        return new RationalNumber((int)Math.Pow(Numerator, power), (int)Math.Pow(Denominator, power)).Reduce();
        // same as one line above
        //var numerator = Math.Pow(Numerator, power);
        //var denominator = Math.Pow(Denominator, power);
        //var rn = new RationalNumber((int)numerator, (int)denominator);  // have to cast to int since Math.Pow returns a double
        //rn.Reduce();
        //return rn;
    }
}
