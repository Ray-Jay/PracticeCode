using System;

public static class Isogram
{
    public static bool IsIsogram(string word)
    {
        word = word.ToLower();

        foreach (char c in word)
        {
            if (Char.IsLetter(c))
            {
                // find first and last index of the current letter. if they don't match, there are duplicates
                if (word.IndexOf(c) != word.LastIndexOf(c)) 
                {
                    return false;
                }
            }
        }

        return true;
    }
}
