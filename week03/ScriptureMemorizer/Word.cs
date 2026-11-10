class Word
{
    private readonly string _text;
    private bool _isHidden;

    public Word(string text)
    {
        _text = text;
        _isHidden = false;
    }

    public bool IsHidden => _isHidden;

    public void Hide()
    {
        _isHidden = true;
    }

    public void Reveal()
    {
        _isHidden = false;
    }

    public string GetRenderedText()
    {
        if (!_isHidden)
        {
            return _text;
        }

        // Replace every letter with an underscore, but keep punctuation
        // (commas, periods, semicolons, etc.) so the structure stays readable.
        char[] rendered = _text.ToCharArray();
        for (int i = 0; i < rendered.Length; i++)
        {
            if (char.IsLetter(rendered[i]))
            {
                rendered[i] = '_';
            }
        }
        return new string(rendered);
    }
}