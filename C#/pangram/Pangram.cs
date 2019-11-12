using System.Linq;

public static class Pangram
{
    public static bool IsPangram(string input)
    {
        return input.ToUpper().Where(ch => char.IsLetter(ch)).Distinct().Count() == 26;
    }
}
