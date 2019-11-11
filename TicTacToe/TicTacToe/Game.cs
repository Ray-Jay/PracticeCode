//  Date: 11-11-19
//  Chapter 20 - Tic Tac Toe
//  Purpose: Create objected-oriented version of Tic-Tac-Toe as console game
//  Class: Game - contains game play logic
using System;

namespace TicTacToe
{
    static class Game
    {
        //  *************************
        //  variables
        //  *************************
        internal static Player[] players = { new Player('X'), new Player('O') };
        private static int startPlayering = 0;
        internal static int currentPlayer;
        internal static bool isNextPlayer;
        internal static bool isNewGame;

        //  *************************
        //  methods
        //  *************************
        //  controls game play logic. loops between 2 plays until winner found or draw
        public static void PlayGame()
        {
            Display.IntroScreen();
            isNewGame = Console.ReadKey().Key == ConsoleKey.Y? true : false;
           
            if (isNewGame)
            {
                Player.GetNames();
            }

            while (isNewGame)              // new game
            {
                Gameboard.Reset();
                currentPlayer = startPlayering;

                while (!Gameboard.isGameDone)   // new letter x / o placement
                {
                    Display.DisplayGameboard();
                    players[currentPlayer].TakeTurn();
                    if (isNextPlayer)
                    {
                        currentPlayer = (currentPlayer + 1) % 2;
                    }
                }
                startPlayering = (startPlayering + 1) % 2;

                Console.Write(" Play Again? Y / N: ");
                isNewGame = Console.ReadKey().Key == ConsoleKey.Y ? true : false;
                Console.WriteLine("\n");
            }

            Display.EndScreen();
        }
    }
}
