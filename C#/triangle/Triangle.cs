using System;

public static class Triangle
{
    public static bool IsScalene(double side1, double side2, double side3)
    {
        bool anyEqual = side1 == side2 || side1 == side3 || side2 == side3;
        bool triangleInequality = (side1 > 0 && side2 > 0 && side3 > 0) && (side1 + side2 >= side3) && (side1 + side3 >= side2) && (side2 + side3 >= side1);

        return !anyEqual && triangleInequality;
    }

    public static bool IsIsosceles(double side1, double side2, double side3)
    {
        bool twoSidesEqual = side1 == side2 || side1 == side3 || side2 == side3;
        bool triangleInequality = (side1 > 0 && side2 > 0 && side3 > 0) && (side1 + side2 >= side3) && (side1 + side3 >= side2) && (side2 + side3 >= side1);

        return twoSidesEqual && triangleInequality;
    }

    public static bool IsEquilateral(double side1, double side2, double side3)
    {
        return (side1 == side2 && side2 == side3 && side1 != 0);
    }
}