using System;

public static class Darts
{
    public static int Score(double x, double y)
    {
        // x and y make up the legs of a triangle. by squaring them and taking the square root, you get the 
        // hypotenuse. if the hypotenuse is <= 10, they'll earn points. from ErikSchierboom
        double hypotenuse = Math.Sqrt(x * x + y * y);

        if (hypotenuse <= 1.0)
            return 10;
        if (hypotenuse <= 5.0)
            return 5;
        if (hypotenuse <= 10.0)
            return 1;

        return 0;
    }
}
