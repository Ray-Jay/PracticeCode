using System;

public static class ArmstrongNumbers
{
    public static bool IsArmstrongNumber(int number)
    {
        int numberLength = number.ToString().Length;
        int tempNumber = number;
        double sum = 0;
        
        // gets last digit of number and raises it to the power of the length of the entire number
        // adds that to the sum. Does this for each digit
        while (tempNumber > 0)
        {
            int digit = tempNumber % 10;
            sum += Math.Pow(digit, numberLength);
            tempNumber = tempNumber / 10;
        }

        return number == sum;
    }
}