using System;
using System.Text;

public static class Raindrops
{
    public static string Convert(int number)
    {
        StringBuilder sb = new StringBuilder();
        bool factor3 = number % 3 == 0;
        bool factor5 = number % 5 == 0;
        bool factor7 = number % 7 == 0;
        bool factor357 = factor3 || factor5 || factor7;

        if (factor3)
        {
            sb.Append("Pling");
        }
        if (factor5)
        {
            sb.Append("Plang");
        }
        if (factor7)
        {
            sb.Append("Plong");
        }
        if (!factor357)
        {
            sb.Append(number.ToString());
        }

        return sb.ToString();
    }
}