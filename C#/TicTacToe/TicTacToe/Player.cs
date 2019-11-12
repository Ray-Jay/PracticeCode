//  Date: 11-11-19
//  Chapter 20 - Tic Tac Toe
//  Purpose: Create objected-oriented version of Tic-Tac-Toe as console game
//  Class: Player - Contains player information and methods for taking a turn
using System;

namespace TicTacToe
{
    class Player
    {
        //  *************************
        //  constructor
        //  *************************
        public Player(char symbol)
        {
            Symbol = symbol;
        }
        //  *************************
        //  variables
        //  *************************
        private bool isValidChoice;
        private char choice;

        //  *************************
        //  properties
        //  *************************
        public string Name { get; set; } = "";
        public char Symbol { get; set; }
        public int Wins { get; set; } = 0;

        //  *************************
        //  methods
        //  *************************

        // prompt player for a number that corresponds to an available space on the gameboard. place letter and check for win
        internal void TakeTurn()
        {
            // repeat until valid number, that is available is entered
            do
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.Write($" {Name}'s turn:\n Select an available number to place your '{Symbol}' => ");
                choice = Console.ReadKey().KeyChar;
                Console.ResetColor();
                Console.WriteLine("\n");
                isValidChoice = Gameboard.ValidateChoice(choice.ToString());
            } while (!isValidChoice);

            Gameboard.PlaceLetter(choice.ToString(), Symbol);
            if (Gameboard.playCounter >= 5)
            {
                Gameboard.CheckForWin();
            }

            if (Gameboard.isGameDone)
            {
                Console.ForegroundColor = ConsoleColor.DarkRed;
                if (!Gameboard.isDraw)
                {
                Console.WriteLine($"\t{Name} won\n");
                Wins++;
                }
                else
                {
                    Console.WriteLine("\tIt's a draw!\n");
                }
                Console.ResetColor();
            }
            else
            {
                Game.isNextPlayer = true;
            }
        }

        //  gets names from both players
        internal static void GetNames()
        {
            Console.Clear();
            Console.WriteLine();
            for (int i = 0; i < 2; i++)
            {
                Console.Write($" Enter Player {i + 1} name => ");
                Game.players[i].Name = Console.ReadLine();
            }
            Console.WriteLine();
        }
    }
}
