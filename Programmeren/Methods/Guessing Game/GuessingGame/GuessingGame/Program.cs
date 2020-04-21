/* This program plays a guessing game with the user. 
 */

using System;

namespace GuessingGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Init();
            Console.WriteLine("\nPress any key to exit.");
            Console.ReadKey();
        }

        // This method initialises the game and asks the user to guess.
        private static void Init()
        {
            Random rand = new Random();
            int randNumber = rand.Next(100) + 1;

            Console.WriteLine("I'm thinking of a number between 1 and 100.\n" +
                "Can you guess what it is?");

            Play(randNumber);
        }

        // This method plays the game.
        private static void Play(int awnser)
        {
            int guess;
            bool validInput;
            do
            {
                do
                {
                    validInput = Int32.TryParse(Console.ReadLine(), out guess);
                    if (!validInput) { Console.WriteLine("Try a number."); }
                } while (!validInput);

                if (guess < awnser) { Console.WriteLine("Too low!"); }
                else if (guess > awnser) { Console.WriteLine("Too high!"); }
            } while (guess != awnser);
            Console.WriteLine("That's it!!!");
        }
    }
}
