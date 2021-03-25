using System;

namespace HotterColder
{
    class Program
    {
        static int defaultValue = 0;

        /// <summary>
        /// Play a game of hotter and colder
        /// </summary>
        /// <param name="args"></param>
        static void Main(string[] args)
        {
            bool userGuessedCorrectly = false;
            int targetNumber = GetRandomNumber(1, 100);
            int lastGuessDistance = defaultValue;

            Console.WriteLine("I have chosen a number between 1 amd 100, please guess it!");

            while(!userGuessedCorrectly)
            {
                Console.WriteLine("Please guess a number and press [Enter]");

                //Get guess
                string guess = Console.ReadLine();
                int iGuess = defaultValue;
                bool parseSuccessful = int.TryParse(guess, out iGuess);
                
                // Check guess is entered correctly
                if (parseSuccessful || iGuess == defaultValue)
                {
                    Console.WriteLine("Guess not a number");
                    continue;
                }

                // Get the distance of the users answer from the target number
                // make sure that the value is always positive with Math.Abs
                int distanceBetweenNumbers = Math.Abs(targetNumber - iGuess);
                
                // If correct guess
                if (iGuess == targetNumber)
                {
                    Console.WriteLine("You Got It!!!!");
                    userGuessedCorrectly = true;
                }
                // If first guess
                else if(lastGuessDistance == defaultValue)
                {
                    if (distanceBetweenNumbers <= 10)
                    {
                        Console.WriteLine("Hot!");
                    }
                    else
                    {
                        Console.WriteLine("Cold!");
                    }
                }
                else if (distanceBetweenNumbers > lastGuessDistance)
                {
                    Console.WriteLine("Colder :-(");
                }
                else if (distanceBetweenNumbers < lastGuessDistance)
                {
                    Console.WriteLine("Hotter!!!");
                }

                lastGuessDistance = distanceBetweenNumbers;
            }

            Console.ReadLine();
        }

        /// <summary>
        /// Get random number between the min and max values
        /// </summary>
        /// <param name="min"></param>
        /// <param name="max"></param>
        /// <returns></returns>
        static int GetRandomNumber(int min, int max)
        {
            int randomNumber = defaultValue;

            Random rnd = new Random();
            randomNumber = rnd.Next(min, max);

            return randomNumber;
        }
    }
}
