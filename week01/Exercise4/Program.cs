using System;

class Program
{
    static void Main(string[] args)
    {
        // Ask the user for a series of numbers until they enter 0
        List<int> numbers = new List<int>();

        Console.WriteLine("Enter a list of numbers, type 0 when finished.");

        int number;
        do
        {
            Console.Write("Enter number: ");
            number = int.Parse(Console.ReadLine());

            // Do not add 0 to the list
            if (number != 0)
            {
                numbers.Add(number);
            }
        } while (number != 0);

        // Core: Compute the sum
        int sum = 0;
        foreach (int n in numbers)
        {
            sum += n;
        }
        Console.WriteLine($"The sum is: {sum}");

        // Core: Compute the average
        // Cast to double so we get a floating-point result, not integer division
        double average = (double)sum / numbers.Count;
        Console.WriteLine($"The average is: {average}");

        // Core: Find the largest number
        int max = numbers[0];
        foreach (int n in numbers)
        {
            if (n > max)
            {
                max = n;
            }
        }
        Console.WriteLine($"The largest number is: {max}");

        // Stretch: Find the smallest positive number
        int smallestPositive = int.MaxValue;
        foreach (int n in numbers)
        {
            if (n > 0 && n < smallestPositive)
            {
                smallestPositive = n;
            }
        }
        if (smallestPositive != int.MaxValue)
        {
            Console.WriteLine($"The smallest positive number is: {smallestPositive}");
        }

        // Stretch: Sort the list and display it
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach (int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}