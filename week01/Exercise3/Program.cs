using System;

class Program
{
    static void Main(string[] args)
    {
        // Stretch Challenge: outer loop to replay the game
        string playAgain = "yes";

        while (playAgain.ToLower() == "yes")
        {
            // Core Requirement: Generate a random number from 1 to 100
            Random random = new Random();
            int magicNumber = random.Next(1, 101);  // 1 inclusive, 101 exclusive

            // Stretch Challenge: track number of guesses
            int guessCount = 0;
            int guess = 0;

            // Core Requirement: loop until the guess matches
            while (guess != magicNumber)
            {
                Console.Write("What is your guess? ");
                guess = int.Parse(Console.ReadLine());
                guessCount++;

                if (guess < magicNumber)
                {
                    Console.WriteLine("Higher");
                }
                else if (guess > magicNumber)
                {
                    Console.WriteLine("Lower");
                }
                else
                {
                    Console.WriteLine("You guessed it!");
                }
            }

            // Stretch Challenge: report number of guesses
            Console.WriteLine($"It took you {guessCount} guesses.");

            // Stretch Challenge: ask to play again
            Console.Write("Do you want to play again? ");
            playAgain = Console.ReadLine();
        }
    }
}