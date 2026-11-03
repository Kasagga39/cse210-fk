using System;

class Program
{
    static void Main(string[] args)
    {
        // Display a welcome message to the user
        DisplayWelcomeMessage();

        // Prompt the user for their name and store it
        string userName = PromptUserName();

        // Prompt the user for their favorite number and store it
        int userNumber = PromptUserNumber();

        // Square the user's number
        int squaredNumber = SquareNumber(userNumber);

        // Display the user's name along with the squared number
        DisplayResult(userName, squaredNumber);
    }

    // Displays a welcome message to the program
    static void DisplayWelcomeMessage()
    {
        Console.WriteLine("Welcome to the program!");
    }

    // Asks for and returns the user's name
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        string name = Console.ReadLine();

        return name;
    }

    // Asks for and returns the user's favorite number
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        int number = int.Parse(Console.ReadLine());

        return number;
    }

    // Accepts an integer and returns that number squared
    static int SquareNumber(int number)
    {
        int square = number * number;
        return square;
    }

    // Accepts the user's name and squared number, and displays them
    static void DisplayResult(string name, int square)
    {
        Console.WriteLine($"{name}, the square of your number is {square}");
    }
}