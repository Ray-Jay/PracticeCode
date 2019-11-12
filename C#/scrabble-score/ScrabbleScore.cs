using System;
using System.Collections.Generic;

public static class ScrabbleScore
{
    enum LetterValues
    {
        AEIOULNRST = 1, 
        DG = 2, 
        BCMP = 3, 
        FHVWY = 4, 
        K = 5, 
        JX = 8, 
        QZ = 10
    }
    public static int Score(string input)
    {
        input = input.ToUpper();
        int sum = 0;

        foreach (char c in input)
        {       
            foreach (string name in Enum.GetNames(typeof(LetterValues)))  // gets string value of each enum
            {
                if (name.Contains(c))
                {
                    Enum.TryParse(name, out LetterValues myValue);      // tries to convert string to enum. if successful, gives a new variable to work with
                    sum += (int)myValue;                                // converts back to enum integer value for the given enum
                }
            }
        }



        return sum;
    }
}