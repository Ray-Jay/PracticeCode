//  Date: 11-1-19
//  C# Mini Project - Wheel of Fortune
//  Class: Game
//  Purpose: Controls game logic and flow. loops through each player, in turn, to try to guess puzzle and accumulate money
using System;

namespace WheelOfFortune
{
    public static class Game
    {
        //  **************************************
        //  variables
        //  ************************************** 
        internal static Player[] players = { new Player(), new Player(), new Player() };
        internal static int[] wheel = { 200, 900, -1, 700, 400, 1000, 600, 300, 0, 100, 500, 800 };  // 0 is for bankrupt.  -1 is for lose a turn
        private static int startPlayering = 0;
        internal static int currentPlayer;
        internal static bool isNextPlayer;
        internal static bool isNewRound;

        //  **************************************
        //  methods
        //  **************************************
        //  game logic. asks player if wants to pla., if so, populates puzzle from file and loops through each player
        //  giving them a chance to guess letters or solve.
        public static void PlayGame()
        {
            // display these once
            Render.IntroScreen();
            isNewRound = Console.ReadKey().Key == ConsoleKey.Y ? true : false;

            if (isNewRound)
            {
                // these only happen once
                Puzzle.PopulatePuzzleList();
                Player.GetNames();
            }

            while (isNewRound)                          // new puzzle
            {
                Render.DisplayBanner();
                Puzzle.SelectNewPuzzle();
                Letterboard.ResetLetters();
                Player.ResetRoundScores();
                Puzzle.isPuzzleSolved = false;
                currentPlayer = startPlayering;   

                while (!Puzzle.isPuzzleSolved)                 // new guess
                {
                    Render.DisplayGameInfo();
                    players[currentPlayer].TakeTurn();
                    if (isNextPlayer) 
                    {
                        currentPlayer = (currentPlayer + 1) % 3;
                    }
                }

                startPlayering = (startPlayering + 1) % 3;

                // if key pressed is yes, check if there are more puzzles. if more puzzles, isNewRound is true, else false (the first one).
                // if key pressed is NOT yes, then isNewRound is also false (the second one).
                // the ternary statement below could be written on one line, but it's harder to understand
                Console.Write(" Play Again? Y / N: ");
                isNewRound = Console.ReadKey().Key == ConsoleKey.Y ? 
                             Puzzle.hasMorePuzzles ? true : false 
                             : false;

                Console.WriteLine();
            }
            
            // if ending while more puzzles available, send blank message. otherwise send message that game is out of puzzles
            Render.EndScreen(Puzzle.hasMorePuzzles ? "" : "********* NO MORE PUZZLES *********");
            Sound.PlaySound("themeMusic.mp4", 10000);
            
            // clean up unmanaged audio resources
            Sound.DisposeAudio();
        }
    }
}
