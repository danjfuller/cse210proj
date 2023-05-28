class Reference
{
    private string _bookAndChapter;
    private int _startVerse;
    private int _endVerse;

    public Reference(string bookAndChapter, int verse)
    {
        _bookAndChapter = bookAndChapter;
        _startVerse = verse;
        _endVerse = verse;
    }

    public Reference(string bookAndChapter, int startVerse, int endVerse)
    {
        _bookAndChapter = bookAndChapter;
        _startVerse = startVerse;
        _endVerse = endVerse;
    }

    // give the reference
    public string GetReference()
    {
        string _reference = $"{_bookAndChapter}:{_startVerse}";
        if(_endVerse > _startVerse)
        {
            _reference += $"-{_endVerse}";
        }
        return _reference;
    }
}