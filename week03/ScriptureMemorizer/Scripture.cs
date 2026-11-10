using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

class Scripture
{
    private readonly Reference _reference;
    private readonly List<Word> _words;
    private readonly Random _random = new Random();

    public Scripture(Reference reference, string text)
    {
        _reference = reference;
        _words = text
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(token => new Word(token))
            .ToList();
    }

    // Hides up to `count` words that are not already hidden.
    // If fewer than `count` remain, hides all remaining ones.
    public void HideRandomWords(int count)
    {
        List<Word> visibleWords = _words.Where(w => !w.IsHidden).ToList();
        if (visibleWords.Count == 0)
        {
            return;
        }

        int toHide = Math.Min(count, visibleWords.Count);
        for (int i = 0; i < toHide; i++)
        {
            int index = _random.Next(visibleWords.Count);
            visibleWords[index].Hide();
            visibleWords.RemoveAt(index);
        }
    }

    // Stretch extra: reveal one random hidden word (hint feature).
    public void RevealRandomWord()
    {
        List<Word> hiddenWords = _words.Where(w => w.IsHidden).ToList();
        if (hiddenWords.Count == 0)
        {
            return;
        }

        hiddenWords[_random.Next(hiddenWords.Count)].Reveal();
    }

    // Stretch extra: reveal every word (show feature).
    public void RevealAll()
    {
        foreach (Word word in _words)
        {
            word.Reveal();
        }
    }

    public bool IsCompletelyHidden()
    {
        return _words.All(w => w.IsHidden);
    }

    public string GetRenderedText()
    {
        StringBuilder builder = new StringBuilder();
        builder.AppendLine(_reference.ToString());

        foreach (Word word in _words)
        {
            builder.Append(word.GetRenderedText());
            builder.Append(' ');
        }

        return builder.ToString().TrimEnd();
    }
}