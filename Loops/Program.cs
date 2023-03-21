using System;
using System.Reflection;

namespace Loops
{
    internal class Program
    {
        static bool winner = false;
        static int winningNumber = 7;
        static bool askedForHint = false;
        static void Main(string[] args)
        {
            GuessingGame();
        }

        /// <summary>
        /// Console Guessing Game: User has 3 attempts to guess the correct number (7) before losing.
        /// Users can ask for "help"/"hint" one time 
        /// </summary>
        public static void GuessingGame()
        {
            for (int i = 3; i > 0; --i)
            {
                Console.WriteLine($"Guess a Number Between 1-10, \n {i} attempts remaining");
                string userInput = Console.ReadLine();

                // user asking for hint/help
                if (userInput.ToLower().Equals("hint") || userInput.ToLower().Equals("help"))
                {
                    // if the user has NOT already asked for a hint
                    if (!askedForHint)
                    {
                        // Giving user a hint
                        Console.WriteLine("It's between 6-8");
                        // Giving them thier guess back
                        i++;
                        // They have now asked for their ONE and ONLY hint
                        askedForHint = true;
                    }
                    // User has already asked for a hint
                    else
                    {
                        Console.WriteLine("You have no more hints left");
                        i++;
                    }
                }
                else
                {
                    // User has NOT asked for hint/help
                    // Parse input into an int
                    Int32.TryParse(userInput, out int userNum);

                    // if you guess correctly
                    if (winningNumber == userNum)
                    {
                        // Winner
                        Console.WriteLine($"{winningNumber} was the correct Number");
                        // Stop Game
                        winner = true;
                        break;
                    }
                    // Keep Guessing
                    else
                    {
                        Console.WriteLine($"{userInput} Wasn't correct");
                    }
                }
            }

            // If you lost the game
            if (!winner)
            {
                Console.WriteLine("\nYou lose\n");
            }

            // asking to play again
            if (PlayAgain())
            {
                // if yes start a new game
                Console.WriteLine("Try asking for a hint this time");
                GuessingGame();
            }

        }
        
        /// <summary>
        /// Prompts user in console to play again if string "y" return true else return false
        /// </summary>
        /// <returns></returns>
        public static bool PlayAgain()
        {
            Console.WriteLine("Play again? y/n?");

            string again = Console.ReadLine();
            if(again.ToLower().Equals("y"))
            {
                return true;
            }
            else
            {
                return false;
            }

        }
    }
}
