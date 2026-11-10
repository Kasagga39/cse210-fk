using System;
using System.Collections.Generic;
using System.IO;

// Models the journal: a collection of entries plus the prompts and file operations.
// Abstraction: it knows about entries and prompts, but 
// beyond simple display helpers.
public class Journal
{
    private const string FieldSeparator = "~|~";
    private List<Entry> _entries = new List<Entry>();

    private readonly List<string> _prompts = new List<string>
    {
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "How did I see the hand of the Lord in my life today?",
        "What was the strongest emotion I felt today?",
        "If I had one thing I could do over today, what would it be?",
        "What is one small thing that made me smile today?",
        "What did I learn today that I did not know yesterday?",
        "What am I most grateful for right now?"
    };

    private readonly Random _random = new Random();

    public int EntryCount => _entries.Count;

    public string GetRandomPrompt()
    {
        int index = _random.Next(_prompts.Count);
        return _prompts[index];
    }

    public void AddEntry(string prompt, string response, string mood)
    {
        string date = DateTime.Now.ToShortDateString();
        Entry entry = new Entry(date, prompt, response, mood);
        _entries.Add(entry);
    }

    public void DisplayAll()
    {
        if (_entries.Count == 0)
        {
            Console.WriteLine("The journal is empty. Write a new entry first.\n");
            return;
        }

        Console.WriteLine($"\n--- Journal ({_entries.Count} entries) ---");
        foreach (Entry entry in _entries)
        {
            entry.Display();
        }
    }

    public void DisplayStatistics()
    {
        Console.WriteLine($"\nTotal entries: {_entries.Count}");
        Console.WriteLine($"Current streak: {CalculateStreak()} day(s)");
        Console.WriteLine();
    }

    // Simple streak: count distinct consecutive days ending today, looking backward.
    // (Locals use camelCase per style requirements.)
    private int CalculateStreak()
    {
        if (_entries.Count == 0)
        {
            return 0;
        }

        HashSet<string> dates = new HashSet<string>();
        foreach (Entry entry in _entries)
        {
            dates.Add(entry.Date);
        }

        int streak = 0;
        DateTime cursor = DateTime.Now.Date;
        while (dates.Contains(cursor.ToShortDateString()))
        {
            streak++;
            cursor = cursor.AddDays(-1);
        }
        return streak;
    }

    // Escape the separator in user content so the file stays parseable.
    private static string Sanitize(string text)
    {
        return text.Replace(FieldSeparator, "~ | ~");
    }

    public void SaveToFile(string filename)
    {
        try
        {
            using (StreamWriter writer = new StreamWriter(filename))
            {
                foreach (Entry entry in _entries)
                {
                    // Build the line manually so we can sanitize each field.
                    string safeDate = Sanitize(entry.Date);
                    string safePrompt = Sanitize(entry.Prompt);
                    string safeResponse = Sanitize(entry.Response);
                    string safeMood = Sanitize(entry.Mood);
                    writer.WriteLine(
                        $"{safeDate}{FieldSeparator}{safePrompt}{FieldSeparator}{safeResponse}{FieldSeparator}{safeMood}");
                }
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error saving journal: {ex.Message}");
        }
    }

    public void LoadFromFile(string filename)
    {
        try
        {
            if (!File.Exists(filename))
            {
                Console.WriteLine($"File '{filename}' not found. Journal unchanged.");
                return;
            }

            List<Entry> loaded = new List<Entry>();
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line))
                {
                    continue;
                }
                loaded.Add(Entry.FromFileLine(line, FieldSeparator));
            }

            // Replace in-memory entries per specification.
            _entries = loaded;
            Console.WriteLine($"Loaded {_entries.Count} entry/entries.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error loading journal: {ex.Message}");
        }
    }
}