using System;

public static class Acronym
{
    // variables
    static string result;
    // abbreviates a phrase
    public static string Abbreviate(string phrase)
    {
        result = "";
        string[] words = phrase.Split(" ");

        // if word has - or _, proceed to special processing. otherwise, add first letter to result
        foreach (string word in words)
        {
            if (word.IndexOf('-') >= 0 || word.IndexOf('_') >= 0)
            {
                CheckSpecialCharacters(word);
            }
            else
            {
                result += Char.ToUpper(word[0]);
            }
        }

        return result;
    }

    // checks words with - and _ to see if need to add to result
    public static void CheckSpecialCharacters(string word)
    {
        bool hasDash = word.IndexOf('-') >= 0;
        bool hasUnderscore = word.IndexOf('_') >= 0;

        if (hasDash && word.Length > 1)
        {
            string[] moreWords = word.Split('-');
            if (moreWords.Length > 0)
            {
                result += Char.ToUpper(moreWords[0][0]);   // first element, first position
                result += Char.ToUpper(moreWords[1][0]);   // second element, first position
            }
        }

        if (hasUnderscore && word.Length > 1)
        {
            string[] moreWords = word.Split('_', StringSplitOptions.RemoveEmptyEntries);
            if (moreWords.Length > 0)
            {
                result += Char.ToUpper(moreWords[0][0]);   
            }
        }
    }
}