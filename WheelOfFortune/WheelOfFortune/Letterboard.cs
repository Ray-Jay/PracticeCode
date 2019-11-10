//  Date: 11-1-19
//  C# Mini Project - Wheel of Fortune
//  Class: Letterboard
//  Purpose: Keeps track of consonants and vowels that are availabe during each round
using System;
using System.Collections.Generic;
using System.Text;

namespace WheelOfFortune
{
    public static class Letterboard
    {
        //  **************************************
        //  variables
        //  ************************************** 
        private static char[] allConsonants = "BCDFGHJKLMNPQRSTVWXYZ".ToCharArray();
        internal static char[] availableConsonants;
        internal static int availableConsonantCount;
        private static char[] allVowels = "AEIOU".ToCharArray();
        internal static char[] availableVowels;
        internal static int availableVowelCount;
        internal static int[] letterIndexes;

        //  **************************************
        //  methods
        //  **************************************
        //  provide a fresh set of letters for each new puzzle
        public static void ResetLetters()
        {
            availableConsonants = new char[allConsonants.Length];
            allConsonants.CopyTo(availableConsonants, 0);
            availableConsonantCount = availableConsonants.Length;
            availableVowels = new char[allVowels.Length];
            allVowels.CopyTo(availableVowels, 0);
            availableVowelCount = availableVowels.Length;
        }

        // checks how many consonants and vowels have been used. if all used up, give a message telling them so
        internal static void CheckLetterCounts()
        {
            if (availableConsonantCount == 0 && availableVowelCount > 0)
            {
                Render.DisplayResultOfChoice("No consonants left. Buy a Vowel or Solve");
            }

            if (availableVowelCount == 0 && availableConsonantCount > 0)
            {
                Render.DisplayResultOfChoice("No vowels left. Spin the Wheel or Solve");
            }

            if (availableVowelCount == 0 && availableConsonantCount == 0)
            {
                Render.DisplayResultOfChoice("No consonants or vowels left. Solve");
            }
        }

        // updates available consonants or vowels for display to players
        internal static void UpdateAvailableLetters(int letterIndex, char letterType)
        {
            if (letterType == 'c')
            {
                availableConsonants.SetValue(' ', letterIndex);
                availableConsonantCount--;
            }
            else                    // vowel
            {
                availableVowels.SetValue(' ', letterIndex);
                availableVowelCount--;
            }
        }

        // checks to see if letter is in puzzle. if so, remove from available letters and reveal in puzzle.
        // if letter not found (or already used) in puzzle, reveal a message telling them so
        internal static bool ValidateLetterChoice(char letter, char letterType)
        {
            // check for letter in puzzle. if found, unmask all and continue turn. if not found, next player's turn
            int letterIndex = letterType == 'c' ? Array.IndexOf(availableConsonants, letter) : Array.IndexOf(availableVowels, letter);
            letterIndexes = Puzzle.Phrase.AllIndexesOf(letter);

            if (letterIndex == -1)                  // letter already called 
            {
                Game.isNextPlayer = true;
                Sound.PlaySound("buzzer.mp3");
                Render.DisplayResultOfChoice($"Sorry, {letter} has already been used in the puzzle. You lose your turn.");
                return false;
            }
            else if (letterIndexes.Length == 0)         // letter does not exist in phrase 
            {
                Game.isNextPlayer = true;
                Sound.PlaySound("buzzer.mp3");
                Render.DisplayResultOfChoice($"Sorry, {letter} is not in the puzzle. You lose your turn.");
                UpdateAvailableLetters(letterIndex, letterType);
                return false;
            }
            else                                        // not called before and exists in phrase
            {
                Game.isNextPlayer = false;
                Sound.PlaySound("puzzleReveal.mp3", 1000);
                string message = letterIndexes.Length > 1 ? $"There are {letterIndexes.Length} {letter}'s" : $"There is {letterIndexes.Length} {letter}";  // plural vs. singular verbiage
                Render.DisplayResultOfChoice($"{message} in the puzzle. It's still your turn.");
                UpdateAvailableLetters(letterIndex, letterType);

                // updated masked phrase to show the letter
                Puzzle.UpdateMaskedPhrase(letterIndexes, letter);
                return true;
            }
        }
    }
}
