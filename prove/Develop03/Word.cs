class Word
{
    private string _word;

    private bool _isBlank = false;

    public Word(string word)
    {
        _word = word;
        _isBlank = false;
    }

    public string FullWord()
    {
        if(_isBlank)
        {
            return BlankedOut(); // give back a blank word
        }
        else
        {
            return _word;
        }
    }

    // returns false if this word is already blanked out
    public bool MakeBlank()
    {
        if(_isBlank)
        {
            return false; // we already are blank. Can't do it again
        }
        else
        {
            _isBlank = true; // make this word blanked out
            return true;
        }
    }

    // makes the word be blank until the program ends
    private string BlankedOut()
    {
        string _blank = "";
        for(int i=0; i<_word.Length; i++)
        {
            _blank += "_";
        }
        return _blank; // this word is now replaced by underscores
    }  
}