using System;

// Models a single journal entry: the date, the prompt, the response, and the mood.
// Nothing here concerns file I/O or menus — that responsibility belongs elsewhere.
public class Entry
{
    private string _date;
    private string _prompt;
    private string _response;
    private string _mood;

    public Entry(string date, string prompt, string response, string mood)
    {
        _date = date;
        _prompt = prompt;
        _response = response;
        _mood = mood;
    }

    public string Date => _date;
    public string Prompt => _prompt;
    public string Response => _response;
    public string Mood => _mood;

    // Serialize to a single separator-delimited line.
    // Separator is "~|~" (unlikely in normal text); it is escaped in Journal before writing.
    public string ToFileLine(char separator)
    {
        return $"{_date}{separator}{_prompt}{separator}{_response}{separator}{_mood}";
    }

    // Build an Entry from a line previously produced by ToFileLine.
    public static Entry FromFileLine(string line, string separator)
    {
        string[] parts = line.Split(new[] { separator }, StringSplitOptions.None);
        // Expect 4 parts. Fallback gracefully if the file is malformed.
        string date = parts.Length > 0 ? parts[0] : "";
        string prompt = parts.Length > 1 ? parts[1] : "";
        string response = parts.Length > 2 ? parts[2] : "";
        string mood = parts.Length > 3 ? parts[3] : "";
        return new Entry(date, prompt, response, mood);
    }

    public void Display()
    {
        Console.WriteLine($"Date: {_date}");
        Console.WriteLine($"Prompt: {_prompt}");
        Console.WriteLine($"Response: {_response}");
        if (!string.IsNullOrWhiteSpace(_mood))
        {
            Console.WriteLine($"Mood: {_mood}");
        }
        Console.WriteLine();
    }
}