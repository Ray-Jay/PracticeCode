using System.Collections.Generic;
using System.Linq;

public class Anagram
{
    // constructor
    public Anagram(string baseWord)
    {
        OriginalWord = baseWord.ToLower();
        OriginalSorted = new string(OriginalWord.OrderBy(c => c).ToArray());
    }
    // properties
    public string OriginalWord { get; set; }
    public string OriginalSorted { get; set; }

    public string[] FindAnagrams(string[] potentialMatches)
    {
        List<string> result = new List<string>();
        string checkWord = "";
        string checkSorted = "";

        // for each word in input array, sort it and compare to the original word
        potentialMatches.ToList().ForEach(element =>
        {
            checkWord = element.ToLower();
            checkSorted = new string(checkWord.OrderBy(c => c).ToArray());
            if (checkSorted == OriginalSorted && OriginalWord != checkWord)
            {
                result.Add(element);
            }
        });

        return result.ToArray();
    }
}