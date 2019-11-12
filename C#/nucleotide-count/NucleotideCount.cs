using System;
using System.Collections.Generic;

public static class NucleotideCount
{
    public static IDictionary<char, int> Count(string sequence)
    {
        // create dictionary with valid nucleotide values and initialize counters to 0
        IDictionary<char, int> nucleotideDict = new Dictionary<char, int>{
        { 'A', 0 },
        { 'C', 0 },
        { 'G', 0 },
        { 'T', 0 }
        };

        // access each letter of the string and check to see if it's in dictionary. If so, get the count currently in the dictionary
        foreach (char nucleotide in sequence)
        {
            if (!nucleotideDict.ContainsKey(nucleotide))
            {
                throw new ArgumentException("*** Invalid Input ***");
            }

            // this is valid nucleotide value, add one to the count and put updated count into dictionary;
            nucleotideDict[nucleotide]++;
        }
        return nucleotideDict;
    }
}