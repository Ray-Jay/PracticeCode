//  Date: 11-1-19
//  C# Mini Project - Wheel of Fortune
//  Class: Render
//  Purpose: Displays information to users for game play. At end, displays grand totals.
using System;
using System.Text;
using System.IO;
using System.Threading;

namespace WheelOfFortune
{
    static class Render
    {
        //  **************************************
        //  methods
        //  **************************************
        //  sets console size, reads file with name of game, displays, and asks if wants to play
        public static void IntroScreen()
        {
            Console.SetWindowSize(80, 30);
            Console.Clear();
            Console.Title = "WHEEL OF FORTUNE";
            Sound.PlaySound("chant.mp3");

            // read in welcome screen a few lines at a time to correspond with the chant sound
            string[] inFile = File.ReadAllLines(@"C:\Users\Apprenti3\Desktop\Wheel of Fortune Project Files\IntroScreen.txt");
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine(inFile[i]);
            }
            Thread.Sleep(1500);
            for (int i = 10; i < 18; i++)
            {
                Console.WriteLine(inFile[i]);
            }
            Thread.Sleep(1500);
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            for (int i = 18; i < inFile.Length; i++)
            {
                Console.WriteLine(inFile[i]);
            }
            Thread.Sleep(1500);

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("\n\n\t\t\t\tPlay Game? Y / N: ");
        }

        // Banner for each guess and end message
        internal static void DisplayBanner()
        {
            //Console.WriteLine("----+----0----+----0----+----0----+----0----+----0----+----0----+----0----+----0");

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("================================================================================");
            Console.WriteLine("=========================== WHEEL OF FORTUNE ===================================");
            Console.WriteLine("================================================================================");
            Console.ResetColor();
        }

        //  display category, masked puzzle, letters, wheel, and round scores 
        internal static void DisplayGameInfo()
        {
            DisplayCategory();
            DisplayMaskedPhrase();
            DisplayLetters();
            DisplayWheel();
            DisplayPlayerAndRoundScores();
        }

        // displays Category to player
        private static void DisplayCategory()
        {
            Console.WriteLine();
            Console.WriteLine($" Category: {Puzzle.Category}");
            Console.WriteLine();
        }

        // displays phrase with spaces between letters to improve readability
        private static void DisplayMaskedPhrase()
        {
            StringBuilder spacedPhrase = new StringBuilder();
            Console.Write(" Puzzle: ");
            foreach (char c in Puzzle.MaskedPhrase)
            {
                spacedPhrase.Append(c.Equals(' ') ? "   " : $"{c} ");
            }
            Console.Write(spacedPhrase);
            Console.WriteLine("\n");   // two new lines
        }

        // displays letters that are available for player selection
        private static void DisplayLetters()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" Available Consonants: ");
            Console.ResetColor();
            Array.ForEach(Letterboard.availableConsonants, letter => Console.Write($"{letter} "));
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write(" Available Vowels    : "); 
            Console.ResetColor();
            Array.ForEach(Letterboard.availableVowels, letter => Console.Write($"{letter} "));
            Console.WriteLine("\n");   // two new lines
        }

        // Displays the wheel. if -1 found display 'Lose_Turn', if 0 found display Bankrupt', else display amount
        private static void DisplayWheel()
        {
            Console.Write(" Wheel: ");
            Array.ForEach(Game.wheel, amount => Console.Write(amount == -1 ? "Lose_Turn " : amount == 0 ? "Bankrupt " : $"${amount} "));
            Console.WriteLine("\n");   // two new lines
        }

        // display accumulated scores during a round
        internal static void DisplayPlayerAndRoundScores()
        {
            Console.WriteLine(" Round Score: ");
            Array.ForEach(Game.players, player => Console.WriteLine($"\t{player.Name.PadRight(15)}  ${player.RoundScore}"));
            Console.WriteLine();
        }

        // show player three options available for each turn
        internal static void DisplayMenuOptions(string name)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($" {name}'s Turn: ");
            Console.ResetColor();
            Console.WriteLine();
            Console.WriteLine($"  Choices: ");
            Console.WriteLine("\t1 - Spin the Wheel");
            Console.WriteLine("\t2 - Buy a Vowel (for $250)");
            Console.WriteLine("\t3 - Solve the puzzle");
            Console.WriteLine();
        }

        // display amount spun on wheel
        internal static void DisplaySpin(string amount)
        {
            Console.WriteLine($"\tSpin Amount: {amount}");
        }

        // after a turn has been taken, display results. If puzzle guessed correctly, also display that
        internal static void DisplayResultOfChoice(string result, string solvedPuzzle = "")
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("##############################################################################");
            Console.WriteLine();
            Console.WriteLine($" {result}");
            Console.WriteLine();
            Console.WriteLine("##############################################################################");
            if (solvedPuzzle.Length > 0)
            {
                Console.WriteLine();
                Array.ForEach(solvedPuzzle.ToCharArray(), letter => Console.Write($" {letter}"));
                Console.WriteLine();
            }
            Console.ResetColor();
        }

        // prints grand totals, thank you message and name of author
        internal static void EndScreen(string message = "")
        {
            //Console.WriteLine("----+----0----+----0----+----0----+----0----+----0----+----0----+----0----+----0");
            Console.Clear();
            Console.WriteLine();
            if (message.Length > 0)
            {
                Console.WriteLine($" {message}");
            }
            Console.WriteLine();
            Console.WriteLine(" =========== GRAND TOTALS ============");
            Array.ForEach(Game.players, player => Console.WriteLine($" Player: {player.Name.PadRight(15)} \t${player.TotalScore}"));
            Console.WriteLine("\n");   // two new lines
            Console.WriteLine("                    T H A N K S  F O R  P L A Y I N G");
            Console.WriteLine();
            DisplayBanner();
            Console.WriteLine();
            string[] inFile = File.ReadAllLines(@"C:\Users\Apprenti3\Desktop\Wheel of Fortune Project Files\Author.txt");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Array.ForEach(inFile, line => Console.WriteLine(line));
            Console.ResetColor();
        }
    }
}