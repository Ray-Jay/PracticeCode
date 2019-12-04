using System;
using System.Collections.Generic;
using System.Text;

public static class WordCount
{
    public static IDictionary<string, int> CountWords(string phrase)
    {
        // remove invalid characters from each word in input phrase
        string[] words = CleanInput(phrase);


        // for each word in array, check if key already exists in dictionary. 
        // if so, update count. if not, add it to the dictionary with a count of 1.
        IDictionary<string, int> wordCounts = new Dictionary<string, int>();
        foreach (string word in words)
            if (wordCounts.ContainsKey(word))
            {
                wordCounts[word]++;
            }
            else
            {
                wordCounts.Add(word, 1);
            }

        return wordCounts;
    }

    private static string[] CleanInput(string phrase)
    {
        // change all commas (,) and newline (\n) to spaces and split into array
        string[] words = phrase.ToLower()
            .Replace(",", " ")
            .Replace("\n", " ")
            .Split(" ", StringSplitOptions.RemoveEmptyEntries);

        // for each word in array, remove leading and trailing apostrophes (') and if the character is a letter,
        // digit, or inner apostrophe, keep it. add the whole word to the output 
        List<string> results = new List<string>();
        foreach (string word in words)
        {
            string wordTrimmed = word.Trim('\'');
            StringBuilder sb = new StringBuilder();
            foreach (char c in wordTrimmed)
            {
                if (Char.IsLetterOrDigit(c) || c == '\'')
                {
                    sb.Append(c);
                }
            }
            results.Add(sb.ToString());
        }
        return results.ToArray();
    }
}