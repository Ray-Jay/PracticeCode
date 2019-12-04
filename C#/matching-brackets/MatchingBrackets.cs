using System;
using System.Collections.Generic;

public static class MatchingBrackets
{
    public static bool IsPaired(string brackets)
    {
        Stack<char> stack = new Stack<char>();
        char[] validOpen = { '{', '(', '[' };
        char[] validClose = { '}', ')', ']' };
        char openBracket;
        int openIndex = Int32.MaxValue;
        int closeIndex = Int32.MinValue;

        foreach (char bracket in brackets)
        {
            // if open symbol, push onto stack
            if (Array.Exists(validOpen, x => x == bracket))
            {
                stack.Push(bracket);
            }
            // if close symbol, pop an item from the stack and compare index postions of valid values. 
            // If not the same, return false.
            if (Array.Exists(validClose, x => x == bracket))
            {

                if (stack.Count == 0) { return false; }

                openBracket = stack.Pop();
                openIndex = Array.IndexOf(validOpen, openBracket);
                closeIndex = Array.IndexOf(validClose, bracket);

                if (openIndex != closeIndex) { return false; }
            }
        }
        return stack.Count == 0;
    }
}
