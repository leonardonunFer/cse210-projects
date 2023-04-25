using System;

namespace GuessTheNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rand = new Random();
            int numberToGuess = rand.Next(1, 101);
            bool gameOver = false;
            while (!gameOver)
            {
                Console.WriteLine("Guess a number between 1 and 100:");
                string userInput = Console.ReadLine();
                int userGuess;
                if (int.TryParse(userInput, out userGuess))
                {
                    if (userGuess == numberToGuess)
                    {
                        Console.WriteLine("Congratulations! You guessed the number.");
                        Console.WriteLine("Do you want to play again? (y/n)");
                        string playAgainInput = Console.ReadLine();
                        if (playAgainInput.ToLower() == "y")
                        {
                            numberToGuess = rand.Next(1, 101);
                        }
                        else
                        {
                            gameOver = true;
                        }
                    }
                    else if (userGuess < numberToGuess)
                    {
                        Console.WriteLine("The number is higher.");
                    }
                    else
                    {
                        Console.WriteLine("The number is lower.");
                    }
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter a valid number.");
                }
            }
            Console.WriteLine("Thanks for playing!");
        }
    }
}
