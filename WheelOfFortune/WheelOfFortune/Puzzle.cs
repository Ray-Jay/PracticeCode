//  Date: 11-1-19
//  C# Mini Project - Wheel of Fortune
//  Class: Puzzle
//  Purpose: Loads available puzzles, selects new puzzle when needed, creates and updates masked puzzle for user display.
using System;
using System.Collections.Generic;
using System.IO;
using System.Diagnostics;
using System.Linq;

namespace WheelOfFortune
{
    static class Puzzle
    {
        //  **************************************
        //  variables
        //  **************************************
        internal static List<string> puzzles = new List<string>();
        internal static HashSet<string> usedPuzzles = new HashSet<string>();
        internal static bool hasMorePuzzles = true;
        internal static bool isPuzzleSolved;

        //  **************************************
        //  properties
        //  **************************************
        public static string Category { get; private set; }
        internal static string Phrase { get; private set; }
        internal static char[] MaskedPhrase { get; set; }

        //  **************************************
        //  methods
        //  **************************************
        // reads csv file with category/puzzle combinations and adds to puzzles list.
        internal static void PopulatePuzzleList()
        {
            string[] inFile = File.ReadAllLines(@"C:\Users\Apprenti3\Desktop\Wheel of Fortune Project Files\AllPuzzles.txt");
            Array.ForEach(inFile, puzzle => puzzles.Add(puzzle));
            if (puzzles.Count == 0)
            {
                hasMorePuzzles = false;
            }

            Debug.WriteLine($"puzzles in file: {puzzles.Count}");
            puzzles.ForEach(puzzle => Debug.WriteLine(puzzle));
        }

        // selects an unused puzzle and creates the masked version
        internal static void SelectNewPuzzle()
        {
            Random rand = new Random();
            int selection;
            string[] currentPuzzle = new string[2];

            // Select a puzzle. Check to see if it  was already used. If used, loop until unused puzzle found
            do
            {
                selection = rand.Next(0, puzzles.Count);
            } while (usedPuzzles.TryGetValue(puzzles[selection], out string duplicateValue));

            usedPuzzles.Add(puzzles[selection]);
            usedPuzzles.ToList().ForEach(u => Debug.WriteLine($"used puzzles: {u}"));

            // if all puzzles used, set hasMorePuzzles flag to false
            if (usedPuzzles.Count == puzzles.Count)
            {
                hasMorePuzzles = false;
            }

            // parse the puzzle to separate the category from the puzzle phrase
            currentPuzzle = puzzles[selection].Split(',');
            Category = currentPuzzle[0];
            Phrase = currentPuzzle[1];
            Debug.WriteLine($"category: {Category} \n{Phrase}");

            // create the masked phrase, preserving original spaces
            MaskedPhrase = new char[Phrase.Length];
            for (int i = 0; i < Phrase.Length; i++)
            {
                MaskedPhrase[i] = Phrase[i].Equals(' ') ? ' ' : '_';
            }
        }

        // places the letter that has been found in the masked phrase
        internal static void UpdateMaskedPhrase(int[] indexes, char letter)
        {
            Array.ForEach(indexes, index => MaskedPhrase[index] = letter);
        }
    }
}