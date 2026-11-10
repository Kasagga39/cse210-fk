// ============================================================================
// CREATIVITY 
// ---------------------------------------------------------------------------
//
// 1. SCRIPTURE LIBRARY: The program loads a library of scriptures from an
//    external file ("scriptures.txt") rather than hard-coding a single
//    scripture.
//
// 2. RANDOM SCRIPTURE SELECTION: Each time the program runs, it picks a
//    scripture from the library at random, giving the user variety.
//
// 3. SMART WORD HIDING (stretch goal): Random word hiding only selects from
//    words that are NOT already hidden, so every press of ENTER makes
//    meaningful progress. A configurable number of words are hidden per turn
//    (default 3), and the last turn hides exactly the remaining words so the
//    scripture always ends fully hidden.
//
// 4. HINT / REVEAL FEATURE: The user can type "hint" to temporarily reveal
//    one hidden word helps when memorizing, and "show" to fully reveal the
//    scripture for a quick refresher before continuing.
//
// 5. INPUT VALIDATION & FEEDBACK: Handles unknown commands gracefully and
//    gives clear prompts so the user always knows what to do.
// ============================================================================

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> library = LoadScriptureLibrary();
        Random random = new Random();
        Scripture scripture = library[random.Next(library.Count)];

        bool running = true;

        while (running)
        {
            Console.Clear();
            Console.WriteLine(scripture.GetRenderedText());
            Console.WriteLine();

            if (scripture.IsCompletelyHidden())
            {
                Console.WriteLine("All words are hidden. Well done!");
                break;
            }

            Console.WriteLine("Press ENTER to hide more words, type 'quit' to exit,");
            Console.WriteLine("'hint' to reveal one word, or 'show' to reveal everything.");
            Console.Write("> ");

            string input = Console.ReadLine()?.Trim().ToLower() ?? string.Empty;

            switch (input)
            {
                case "":
                    scripture.HideRandomWords(3);
                    break;
                case "quit":
                    running = false;
                    break;
                case "hint":
                    scripture.RevealRandomWord();
                    break;
                case "show":
                    scripture.RevealAll();
                    break;
                default:
                    Console.WriteLine("Unrecognized command. Press ENTER to continue.");
                    Console.ReadLine();
                    break;
            }
        }

        Console.WriteLine("Press ENTER to close.");
        Console.ReadLine();
    }

    private static List<Scripture> LoadScriptureLibrary()
    {
        List<Scripture> library = new List<Scripture>();
        string path = "scriptures.txt";

        if (File.Exists(path))
        {
            foreach (string rawLine in File.ReadAllLines(path))
            {
                string line = rawLine.Trim();
                if (line.Length == 0 || line.StartsWith("#"))
                {
                    continue;
                }

                string[] parts = line.Split('|', 2);
                if (parts.Length == 2)
                {
                    library.Add(new Scripture(new Reference(parts[0].Trim()), parts[1].Trim()));
                }
            }
        }

        if (library.Count == 0)
        {
            // Fallback library so the program always works.
            library.Add(new Scripture(
                new Reference("John", 3, 16),
                "For God so loved the world, that he gave his only begotten Son, " +
                "that whosoever believeth in him should not perish, but have everlasting life."));
            library.Add(new Scripture(
                new Reference("Proverbs", 3, 5, 6),
                "Trust in the Lord with all thine heart; and lean not unto thine own understanding. " +
                "In all thy ways acknowledge him, and he shall direct thy paths."));
        }

        return library;
    }
}