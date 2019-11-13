using System;
using System.Linq;

public static class Bob
{
    [Flags]
    public enum StatementAttributes
    {
        Empty =     1 << 0,   //  1 or 00000001     
        Question =  1 << 1,   //  2 or 00000010     
        AllCaps =   1 << 2,   //  4 or 00000100     
        Unused1 = 0,
        Unused2 = 0,
        Unused3 = 0,
        Unused4 = 0,
        AllOn =     7         //  7 or 00000111
    }

    public static string Response(string statement)
    {
        // create new field to hold attributes for a statement
        StatementAttributes attributes = StatementAttributes.Unused1;
        bool isEmpty = IsEmpty(statement);
        bool isQuestion = IsQuestion(statement);
        bool isAllCaps = !isEmpty && IsAllCaps(statement);

        // Check for attributes to turn on 
        if (isEmpty)
        {
            attributes |= StatementAttributes.Empty;        // Turn on the 'empty' field 
        }

        if (isQuestion)
        {
            attributes |= StatementAttributes.Question;     // Turn on the 'question' field 
        }

        if (isAllCaps)
        {
            attributes |= StatementAttributes.AllCaps;      // Turn on the 'all caps' field 
        }

        int result = (int)(StatementAttributes.AllOn & attributes);
        string bobResponse;

        switch (result)
        {
            case 1:
                bobResponse = "Fine. Be that way!";
                break;
            case 2:
                bobResponse = "Sure.";
                break;
            case 4:
                bobResponse = "Whoa, chill out!";
                break;
            case 6:
                bobResponse = "Calm down, I know what I'm doing!";
                break;
            default:
                bobResponse = "Whatever.";
                break;
        }
        return bobResponse;
    }

    // check if input string has any letters. if not, return false. if so, check for all uppercase.
    static bool IsAllCaps(string input)
    {
        bool hasLetter = input.Any(index => Char.IsLetter(index));

        foreach (char c in input)
        {
            if (Char.IsLetter(c) && !Char.IsUpper(c))
            {
                    return false;
            }
        }
        return true && hasLetter;
    }

    // trim string and check if there are any characters left. trim removes \n, \r, \t and outer spaces
    static bool IsEmpty(string input)
    {
        return input.Trim().Length == 0;
    }

    // trim end of string and check if the last charactre is a question mark
    static bool IsQuestion(string input)
    {
        string trimmed = input.TrimEnd();
        return trimmed.Length > 0 ? trimmed[trimmed.Length - 1].Equals('?') : false;
    }
}