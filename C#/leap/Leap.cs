using System;

public static class Leap
{
    public static bool IsLeapYear(int year)
    {
        bool divBy4 = year % 4 == 0;
        bool divBy100 = year % 100 == 0;
        bool divBy400 = year % 400 == 0;
        
        return (divBy4 && !divBy100 && !divBy400) || (divBy4 && divBy400);
    }
}