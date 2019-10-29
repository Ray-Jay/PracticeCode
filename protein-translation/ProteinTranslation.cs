using System;
using System.Collections.Generic;
public static class ProteinTranslation
{
    // create class variable that can be used in FindMatch method
    //static string substring3;

    public static string[] Proteins(string strand)
    {
        List<string> results = new List<string>();
        bool isStop = false;

        // codons in an array
        string[] codons = new string[]
            {
                "AUG",                      // index 0
                "UUU, UUC",                 // index 1
                "UUA, UUG",                 // index 2
                "UCU, UCC, UCA, UCG",       // index 3
                "UAU, UAC",                 // index 4
                "UGU, UGC",                 // index 5
                "UGG",                      // index 6
                "UAA, UAG, UGA",            // index 7
            };

        // proteins in an array that matches the positions of codons
        string[] proteins = new string[]
            {
                "Methionine",               // index 0
                "Phenylalanine",            // index 1
                "Leucine",                  // index 2
                "Serine",                   // index 3
                "Tyrosine",                 // index 4
                "Cysteine",                 // index 5
                "Tryptophan",               // index 6
                "STOP",                     // index 7
            };

        // loop through every 3 characters in input strand
        // use FindIndex returns index position in codons array
        // if not a stop index, add to list 
        for (int i = 0; i < strand.Length && !isStop; i += 3)
        {
            string substring3 = strand.Substring(i, 3);
            //int index = Array.FindIndex(codons, FindMatch);   // FindIndex sends each element of the codons array to the FindMatch method, one at a time
            int index = Array.FindIndex(codons, codon => codon.Contains(substring3) ? true : false);   // FindIndex sends each element of the codons array to the lambda expression, one at a time
            if (index == 7)  // stop characters
            {
                isStop = true;
                continue;
            }
            results.Add(proteins[index]);
        }

        return results.ToArray();
    }

    // if chose to create named method, this would work. k
    // ** would need to uncomment lines 6 and line 45. comment line 46 & remove 'string' from line 44
    //checks if the 3-character substring is found in the current codon
    //private static bool FindMatch(String codon)
    //{
    //    return codon.Contains(substring3) ? true : false;
    //}
}