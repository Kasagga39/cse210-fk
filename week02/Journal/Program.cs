using System;

// =====================================================================================
// CREATIVITY:
//
// 1. MOOD TRACKING: Each entry also records a "mood" (a simple word/phrase the user
//    provides). This addresses the barrier "We don't feel like we have anything
//    interesting to say" by encouraging a quick emotional snapshot — low effort,
//    high value. Mood is displayed when entries are shown.
//
// 2. ENTRY COUNT: The journal tracks and reports the total number of entries
//    and the current consecutive-day streak, giving the user motivating feedback.
//
// 3. ROBUST SEPARATOR HANDLING: Uses "~|~" as the field separator and sanitizes any
//    separator occurrences in user input so save/load never corrupts data.
//
// 4. AUTO-DEFAULT FILENAME & SAFE LOAD: If the user presses Enter for the filename,
//    it defaults to "journal.txt". If the file doesn't exist, it informs the user instead of crashing.
//
// 5. PROMPT LIST > 5: Provides 8 original prompts.
//
// =====================================================================================

class Program
{
    static void Main(string[] args)
    {
        Journal journal = new Journal();
        bool running = true;

        Console.WriteLine("Welcome to the Journal Program!");
        Console.WriteLine("A simple way to capture a few thoughts each day.\n");

        while (running)
        {
            Console.WriteLine("Please select one of the following choices:");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Save the journal to a file");
            Console.WriteLine("4. Load the journal from a file");
            Console.WriteLine("5. Show journal statistics");
            Console.WriteLine("6. Quit");
            Console.Write("What would you like to do? ");

            string choice = Console.ReadLine()?.Trim();

            switch (choice)
            {
                case "1":
                    WriteNewEntry(journal);
                    break;
                case "2":
                    journal.DisplayAll();
                    break;
                case "3":
                    SaveJournal(journal);
                    break;
                case "4":
                    LoadJournal(journal);
                    break;
                case "5":
                    journal.DisplayStatistics();
                    break;
                case "6":
                    running = false;
                    Console.WriteLine("Goodbye! Keep journaling.");
                    break;
                default:
                    Console.WriteLine("Invalid choice. Please enter a number 1-6.\n");
                    break;
            }
        }
    }

    // ----- Helper methods for user interaction (keeps Program lean) -----

    private static void WriteNewEntry(Journal journal)
    {
        string prompt = journal.GetRandomPrompt();
        Console.WriteLine($"\nPrompt: {prompt}");

        Console.Write("Your response: ");
        string response = Console.ReadLine() ?? string.Empty;

        Console.Write("How would you describe your mood today (one word)? ");
        string mood = Console.ReadLine() ?? string.Empty;

        journal.AddEntry(prompt, response, mood);
        Console.WriteLine("Entry added.\n");
    }

    private static void SaveJournal(Journal journal)
    {
        Console.Write("Enter filename to save to (Enter for 'journal.txt'): ");
        string filename = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(filename))
        {
            filename = "journal.txt";
        }

        journal.SaveToFile(filename);
        Console.WriteLine($"Journal saved to '{filename}'.\n");
    }

    private static void LoadJournal(Journal journal)
    {
        Console.Write("Enter filename to load from (Enter for 'journal.txt'): ");
        string filename = Console.ReadLine()?.Trim();
        if (string.IsNullOrWhiteSpace(filename))
        {
            filename = "journal.txt";
        }

        journal.LoadFromFile(filename);
        Console.WriteLine($"Journal loaded from '{filename}'.\n");
    }
}