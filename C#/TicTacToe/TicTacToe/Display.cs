//  Date: 11-11-19
//  Chapter 20 - Tic Tac Toe
//  Purpose: Create objected-oriented version of Tic-Tac-Toe as console game
//  Class: Display - displays board updates and messages to user
using System;
using System.IO;

namespace TicTacToe
{
    static class Display
    {
        //  *************************
        //  variables
        //  *************************
        static string[] inFile;

        //  *************************
        //  methods
        //  *************************

        //  shows updated screen
        internal static void DisplayGameboard()
        {
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Gameboard.board[0,0], Gameboard.board[0,1], Gameboard.board[0,2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Gameboard.board[1, 0], Gameboard.board[1, 1], Gameboard.board[1, 2]);
            Console.WriteLine("_____|_____|_____ ");
            Console.WriteLine("     |     |      ");
            Console.WriteLine("  {0}  |  {1}  |  {2}", Gameboard.board[2, 0], Gameboard.board[2, 1], Gameboard.board[2, 2]);
            Console.WriteLine("     |     |      \n");
        }

        // displays intro title
        public static void IntroScreen()
        {
            Console.SetWindowSize(52, 30);
            Console.Clear();
            Console.Title = "Tic-Tac-Toe";

            // read in welcome screen a few lines at a time to change colors
            inFile = File.ReadAllLines(@"C:\Users\Apprenti3\Desktop\TicTacToe\gameImage.txt");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int i = 0; i < 8; i++)
            {
                Console.WriteLine(inFile[i]);
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for (int i = 8; i < inFile.Length; i++)
            {
                Console.WriteLine(inFile[i]);
            }

            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.Write("\n\n\t\tPlay Game? Y / N: ");
            Console.ResetColor();
        }

        // displays names and final win counts
        public static void EndScreen()
        {
            Console.Clear();
            Console.WriteLine();
            Console.WriteLine("\t T H A N K S   F O R   P L A Y I N G");
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkCyan;
            for (int i = 6; i < 8; i++)
            {
                Console.WriteLine(inFile[i]);
            }
            Console.ForegroundColor = ConsoleColor.DarkMagenta;
            for (int i = 8; i < inFile.Length; i++)
            {
                Console.WriteLine(inFile[i]);
            }
            Console.ResetColor();

            // display final scores
            Array.ForEach(Game.players, player => Console.WriteLine($"\t{player.Name.PadRight(12)}  Wins: {player.Wins}"));
            Console.WriteLine($"\n\tDraws: {Gameboard.drawCounter}");
            Console.WriteLine("\n\tby Radiah Jones");
        }
    }
}
