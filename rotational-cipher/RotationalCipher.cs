using System;
using System.Text;
enum Letters
{
    a = 1, b, c, d, e, f, g, h, i, j, k, l, m, n, o, p, q, r, s, t, u, v, w, x, y, z
}
public static class RotationalCipher
{
    public static string Rotate(string text, int shiftKey)
    {
        StringBuilder sb = new StringBuilder();

        if (shiftKey > 0)
        {
            foreach (char character in text)
            {
                bool isUpper = Char.IsUpper(character) ? true : false;

                if (Char.IsLetter(character))   // if letter, shift
                {
                    // take the character and find the position in the enum. 
                    Letters letterPositionInEnum = (Letters)System.Enum.Parse(typeof(Letters), character.ToString(), true);

                    // cast the position found to an integer and apply the shiftKey
                    int newLetter = (int)letterPositionInEnum + shiftKey;

                    // If the number is great than 26 (end of enum) subtract 26 to get to proper letter
                    if (newLetter > 26)
                    {
                        newLetter -= 26;
                    }

                    // if letter was marked as uppercase in beginning, change the value back to uppercase
                    if (isUpper)
                    {
                        Letters upperLetter = (Letters)newLetter;
                        string newUpLet = upperLetter.ToString().ToUpper();
                        sb.Append(newUpLet);
                    }
                    else
                    {
                        sb.Append((Letters)newLetter);
                    }
                }
                else     // not a letter, just add to output
                {
                    sb.Append(character);
                }
            }
        }
        else     // no shift, send back original text;
        {
            sb.Append(text);
        }
        return sb.ToString();
    }
}