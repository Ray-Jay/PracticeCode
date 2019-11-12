using System;
using System.Text;

public class PhoneNumber
{
    public static string Clean(string phoneNumber)
    {
        StringBuilder sb = new StringBuilder();
        
        // get digits only
        foreach (char c in phoneNumber)
        {
            if (Char.IsDigit(c))
                sb.Append(c);
        }

        // throw out anything that isn't length of 10 or 11
        if (sb.Length != 10 && sb.Length != 11)
        {
            throw new ArgumentException("*** Invalid Entry ***");
        }

        // if 11, check country code at position 0. If not 1, discard, otherwise remove the country code
        if (sb.Length == 11)
        {
            if (sb[0] != '1')
                throw new ArgumentException("*** Invalid Country Code ***");
            else
                sb.Remove(0, 1);
        }

        // now the number is 10 digits. check positions 0 and 3 for numbers 2-9 only
        if (sb[0] == '0' || sb[0] == '1' || sb[3] == '0' | sb[3] == '1')       // don't forget, these are strings, not integers
        {
            throw new ArgumentException("*** Invalid Area or Exchange Code ***");
        }

        return sb.ToString();
    }
}