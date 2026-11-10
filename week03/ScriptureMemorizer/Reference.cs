using System;

class Reference
{
    private readonly string _book;
    private readonly int _chapter;
    private readonly int _startVerse;
    private readonly int _endVerse;

    // Constructor for a single verse, e.g. "John 3:16"
    public Reference(string book, int chapter, int verse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    // Constructor for a verse range, e.g. "Proverbs 3:5-6"
    public Reference(string book, int chapter, int startVerse, int endVerse)
    {
        _book = book;
        _chapter = chapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // Convenience constructor that parses a string like "John 3:16" or
    // "Proverbs 3:5-6" (used when loading from a file).
    public Reference(string referenceText)
    {
        referenceText = referenceText.Trim();

        int spaceIndex = referenceText.LastIndexOf(' ');
        if (spaceIndex < 0)
        {
            throw new FormatException($"Invalid reference format: '{referenceText}'");
        }

        _book = referenceText.Substring(0, spaceIndex).Trim();
        string versePart = referenceText.Substring(spaceIndex + 1).Trim();

        string[] chapterVerse = versePart.Split(':');
        _chapter = int.Parse(chapterVerse[0]);

        if (chapterVerse[1].Contains('-'))
        {
            string[] range = chapterVerse[1].Split('-');
            _startVerse = int.Parse(range[0]);
            _endVerse = int.Parse(range[1]);
        }
        else
        {
            _startVerse = int.Parse(chapterVerse[1]);
            _endVerse = _startVerse;
        }
    }

    public override string ToString()
    {
        return _startVerse == _endVerse
            ? $"{_book} {_chapter}:{_startVerse}"
            : $"{_book} {_chapter}:{_startVerse}-{_endVerse}";
    }
}