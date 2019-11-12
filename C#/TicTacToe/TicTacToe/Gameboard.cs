//  Date: 11-11-19
//  Chapter 20 - Tic Tac Toe
//  Purpose: Create objected-oriented version of Tic-Tac-Toe as console game
//  Class: Gameboard - 3x3 array that holds player values
using System;
using System.Collections.Generic;

namespace TicTacToe
{
    static class Gameboard
    {
        //  *************************
        //  variables
        //  *************************
        internal static int playCounter;
        internal static int drawCounter;
        internal static bool isGameDone;
        internal static bool isDraw;
        internal static bool isWon;
        private static char[,] initialBoard = { { '7', '8', '9' },
                                                { '4', '5', '6' },
                                                { '1', '2', '3' } };
        internal static char[,] board = new char[3, 3];
        private static List<int> numberOptions;

        //  *************************
        //  methods
        //  *************************
        //  reset board, playCounter, isDraw and isGameDone flags at beginning of each new game
        internal static void Reset()
        {
            playCounter = 0;
            isGameDone = false;
            isDraw = false;
            isWon = false;
            numberOptions = new List<int> { 1, 2, 3, 4, 5, 6, 7, 8, 9 };
            Array.Copy(initialBoard, board, initialBoard.Length);
        }

        // confirm that user selected a valid, available number
        internal static bool ValidateChoice(string choice)
        {
            bool isANumber = Int32.TryParse(choice, out int number);
            int index = numberOptions.IndexOf(number);

            if (!isANumber || number == 0 || index == -1)
            {
                return false;
            }
            numberOptions.RemoveAt(index);   // if number is available, remove it
            return true;
        }

        // put the X or O in the array and increment the playCounter
        internal static void PlaceLetter(string choice, char symbol)
        {
            int row = -1;
            int column = -1;
            int number = Convert.ToInt32(choice);

            switch (number)   // find row
            {
                case 7:
                case 8:
                case 9:
                    row = 0;
                    break;
                case 4:
                case 5:
                case 6:
                    row = 1;
                    break;
                case 1:
                case 2:
                case 3:
                    row = 2;
                    break;
            }

            switch (number)   // find column
            {
                case 1:
                case 4:
                case 7:
                    column = 0;
                    break;
                case 2:
                case 5:
                case 8:
                    column = 1;
                    break;
                case 3:
                case 6:
                case 9:
                    column = 2;
                    break;
            }

            board[row, column] = symbol;
            playCounter++;
        }

        // check each row, column and diagonal for win. If play count == 9 and no winner found, declare a draw
        internal static void CheckForWin()
        {
            bool row1 = board[0, 0] == board[0, 1] && board[0, 1] == board[0, 2];
            bool row2 = board[1, 0] == board[1, 1] && board[1, 1] == board[1, 2];
            bool row3 = board[2, 0] == board[2, 1] && board[2, 1] == board[2, 2];
            bool col1 = board[0, 0] == board[1, 0] && board[1, 0] == board[2, 0];
            bool col2 = board[0, 1] == board[1, 1] && board[1, 1] == board[2, 1];
            bool col3 = board[0, 2] == board[1, 2] && board[1, 2] == board[2, 2];
            bool diagonal1 = board[0, 0] == board[1, 1] && board[1, 1] == board[2, 2];
            bool diagonal2 = board[0, 2] == board[1, 1] && board[1, 1] == board[2, 0];

            if (row1 || row2 || row3 ||
                col1 || col2 || col3 ||
                diagonal1 || diagonal2)
            {
                isGameDone = true;
                isWon = true;
                Display.DisplayGameboard();
            }

            if (playCounter == 9)
            {
                isGameDone = true;
                if (!isWon)
                {
                    isDraw = true;
                    drawCounter++;
                }
                Display.DisplayGameboard();
            }

        }
    }
}
