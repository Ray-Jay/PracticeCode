using System;
using System.Text;

public static class BeerSong
{
    public static string Recite(int startBottles, int takeDown)
    {
        StringBuilder sb = new StringBuilder();
        for (int i = 0; i < takeDown; i++)
        {
            if (startBottles - i > 2)  // all plural bottles
            {
                sb.Append($"{startBottles - i} bottles of beer on the wall, {startBottles - i} bottles of beer.");
                sb.Append($"\nTake one down and pass it around, {startBottles - i - 1} bottles of beer on the wall.");
            }
            else if (startBottles - i == 2)  // one plural and one single bottle
            {
                sb.Append($"{startBottles - i} bottles of beer on the wall, {startBottles - i} bottles of beer.");
                sb.Append($"\nTake one down and pass it around, {startBottles - i - 1} bottle of beer on the wall.");
            }
            else if (startBottles - i == 1)  // one single bottle and no more bottles
            {
                sb.Append($"{startBottles - i} bottle of beer on the wall, {startBottles - i} bottle of beer.");
                sb.Append($"\nTake it down and pass it around, no more bottles of beer on the wall.");
            }
            else                            // no more bottles
            {
                sb.Append($"No more bottles of beer on the wall, no more bottles of beer.");
                sb.Append($"\nGo to the store and buy some more, 99 bottles of beer on the wall.");
            }

            if (takeDown > 1 && startBottles - 1 != 0 && i != takeDown - 1)     // add newlines after set of lines, if not the end
            {
                sb.Append("\n\n");
            }
        }

        return sb.ToString();
    }
}