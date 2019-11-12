//  Date: 11-1-19
//  C# Mini Project - Wheel of Fortune
//  Class: Extension Methods
//  Purpose: Contains methods to extend functionality of types
using System.Linq;

namespace WheelOfFortune
{
    static class ExtensionMethods
    {
        // finds all occurrences of a letter in a string and returns the index positions. 
        // if none found, returns int[0]
        public static int[] AllIndexesOf(this string phrase, char searchCharacter)
        {
            return phrase.Select((letter, index) => letter == searchCharacter ? index : -1).Where(index => index != -1).ToArray();
        }
    }
}
