//  Date: 11-1-19
//  C# Mini Project - Wheel of Fortune
//  Class: Player
//  Purpose: Allows creation of player objects that hold name and score information. Methods allow a player to take a turn.
using System;

namespace WheelOfFortune
{
    class Player
    {
        //  **************************************
        //  properties
        //  ************************************** 
        public string Name { get; set; } = "None";
        public int RoundScore { get; set; }
        public int TotalScore { get; set; } = 0;
        public int SpinAmount { get; set; }

        //  **************************************
        //  methods
        //  ************************************** 
        //  loops to get name of each player in players array
        internal static void GetNames()
        {
            Console.ResetColor();
            Console.Clear();
            Console.WriteLine();
            for (int i = 0; i < 3; i++)
            {
                Console.Write($" Enter Player {i + 1} name => ");
                Game.players[i].Name = Console.ReadLine();
            }
        }

        // after a puzzle is guessed correctly, reset round scores if players choose to play again
        internal static void ResetRoundScores()
        {
            Array.ForEach(Game.players, player => player.RoundScore = 0);
        }

        // gives player 3 choices, spin, buy a vowel, or guess. Branches based on selection
        internal void TakeTurn()
        {
            // display choices and ask for selection
            Render.DisplayMenuOptions(Name);

            // tell person what to choose if consonants or vowels are gone
            Letterboard.CheckLetterCounts();
            bool isNumber;
            int choice;
            do
            {
                Console.Write("\tWhat is your choice?: ");
                isNumber = Int32.TryParse(Console.ReadLine(), out choice);
            } while (!isNumber || choice < 1 || choice > 3);

            // branch based on choice
            switch (choice)
            {
                case 1:
                    SpinWheel();
                    break;
                case 2:
                    BuyAVowel();
                    break;
                case 3:
                    SolvePuzzle();
                    break;
            }
        }

        // spins wheel for an amount. if not bankrupt or lose-a-turn, guess a letter and attempt to earn money
        private void SpinWheel()
        {
            Random rand = new Random();
            SpinAmount = Game.wheel[rand.Next(12)];  // wheel has 12 items, indexes 0 - 11
            Sound.PlaySound("wheelSpin.mp3", 4000);

            // branch based on spin
            switch (SpinAmount)
            {
                case 0:
                    RoundScore = 0;
                    Game.isNextPlayer = true;
                    Render.DisplaySpin("Bankrupt!");
                    Console.WriteLine();
                    Sound.PlaySound("bankrupt.mp3");
                    Render.DisplayResultOfChoice("Bankrupt! Sorry, you lose your money from this round and your turn.");
                    break;
                case -1:
                    Game.isNextPlayer = true;
                    Render.DisplaySpin("Lose-A-Turn");
                    Console.WriteLine();
                    Sound.PlaySound("bankrupt.mp3");
                    Render.DisplayResultOfChoice("Lose-A-Turn! Sorry, you lose your turn.");
                    break;
                default:
                    Render.DisplaySpin($"${SpinAmount}");
                    SelectConsonant();
                    break;
            }
        }

        // Attempt to find a consonant. If found, add money to RoundScore and continue turn. if not, lose the turn.
        private void SelectConsonant()
        {
            Console.Write("\tWhat consonant do you chose?: ");
            char consonant = Char.ToUpper(Console.ReadKey().KeyChar);
            Console.WriteLine("\n");      // two new lines
            bool isConsonant = "BCDFGHJKLMNPQRSTVWXYZ".IndexOf(consonant) >= 0;

            if (isConsonant)
            {
                bool isEarnMoney = Letterboard.ValidateLetterChoice(consonant, 'c');
                if (isEarnMoney)
                {
                    // multiply spin amount * the count of letters and add to RoundScore
                    RoundScore += SpinAmount * Letterboard.letterIndexes.Length;
                }
            }
            else
            {
                Game.isNextPlayer = true;
                Sound.PlaySound("buzzer.mp3");
                Render.DisplayResultOfChoice($"Sorry, {consonant} is not a consonant. You lose your turn.");
            }
        }

        // Attempt to buy a vowel. If have enough money, try to find vowel. If found, reveal and continue turn. If not, lose the turn.
        private void BuyAVowel()
        {
            if (RoundScore >= 250)
            {
                RoundScore -= 250;
                Console.Write("\tWhat vowel do you chose?: ");
                char vowel = Char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine();
                bool isVowel = "AEIOU".IndexOf(vowel) >= 0;
                if (isVowel)
                {
                    Letterboard.ValidateLetterChoice(vowel, 'v');
                }
                else                        // not a vowel
                {
                    Sound.PlaySound("buzzer.mp3");
                    Game.isNextPlayer = true;
                    Render.DisplayResultOfChoice($"Sorry, {vowel} is not a vowel. You lose your turn.");
                }
            }
            else                            // don't have enough money to buy a vowel
            {
                Sound.PlaySound("buzzer.mp3");
                Game.isNextPlayer = true;
                Render.DisplayResultOfChoice("Sorry, you don't have enough money to buy a vowel. You lose your turn.");
            }
        }

        // Attempt to solve the puzzle. If correct, add RoundScore to TotalScore. If not, lose the turn.
        private void SolvePuzzle()
        {
            Console.Write("\tWhat is your guess?: ");
            string guess = Console.ReadLine().ToUpper();
            Console.WriteLine();

            if (guess == Puzzle.Phrase)
            {
                Puzzle.isPuzzleSolved = true;
                Render.DisplayResultOfChoice("That is correct, you solved the puzzle!", Puzzle.Phrase);
                Console.WriteLine();
                Sound.PlaySound("puzzleSolve.mp3", 1000);
                // if player has less than $1000 when won round, give minimum of $1000
                string minimum = "";
                if (RoundScore < 1000)
                {
                    RoundScore = 1000;
                    minimum = "minimum";
                }
                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine($" {Name} wins ${RoundScore} {minimum}");
                Console.ResetColor();
                Console.WriteLine();
                TotalScore += RoundScore;

                // to display current rounds scores after a win
                int tempScore = RoundScore;
                ResetRoundScores();
                RoundScore = tempScore;
                Render.DisplayPlayerAndRoundScores();
            }
            else                                   // attempt to solve puzzle is incorrect
            {
                Sound.PlaySound("buzzer.mp3");
                Game.isNextPlayer = true;
                Render.DisplayResultOfChoice("That is not correct. You lose your turn.");
            }
        }
    }
}