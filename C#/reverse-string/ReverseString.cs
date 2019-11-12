//  Date: 10-22-19
//  Exercism ReverseString
//  Purpose: Receive and input string and reverse it

using System;

public static class ReverseString
{
    public static string Reverse(string input)
    {
        char[] asArray = input.ToCharArray();
        Array.Reverse(asArray);
        return new string(asArray);
    }
}