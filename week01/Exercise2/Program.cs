using System;

class Program
{
    static void Main(string[] args)
    {
        // Core Requirement 1 & 2: Ask for grade percentage
        Console.Write("What is your grade percentage? ");
        string gradeInput = Console.ReadLine();
        int percentage = int.Parse(gradeInput);

        // Core Requirement 3: Determine letter grade into a variable
        string letter = "";

        if (percentage >= 90)
        {
            letter = "A";
        }
        else if (percentage >= 80)
        {
            letter = "B";
        }
        else if (percentage >= 70)
        {
            letter = "C";
        }
        else if (percentage >= 60)
        {
            letter = "D";
        }
        else
        {
            letter = "F";
        }

        // Stretch Challenge: Determine the sign (+, -, or none)
        string sign = "";
        int lastDigit = percentage % 10;

        if (lastDigit >= 7)
        {
            sign = "+";
        }
        else if (lastDigit < 3)
        {
            sign = "-";
        }
        else
        {
            sign = "";
        }

        // Stretch Challenge: Handle exceptional cases (no A+, F+, F-)
        if (letter == "A" && sign == "+")
        {
            sign = "";
        }
        else if (letter == "F")
        {
            sign = "";
        }

        // Print the letter grade and sign in one statement
        Console.WriteLine($"Your grade is {letter}{sign}.");

        // Core Requirement 2: Pass/fail message
        if (percentage >= 70)
        {
            Console.WriteLine("Congratulations, you passed the course!");
        }
        else
        {
            Console.WriteLine("Keep trying! You'll get it next time.");
        }
    }
}