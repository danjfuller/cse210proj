class Scripture
{
    private string _scripture;
    private Reference _reference;
    private List<Word> _words;
    private int blankedOut = 0; // how many words to blank out each time we print

    public Scripture()
    {
        _scripture = "Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.";
        _reference = new Reference("Proverbs 3:5-6");
        _words = new List<Word>();
        SplitVerseIntoWords(); // turn the string into a list of words
    }

    // if the coder wants to make a custom scripture to memorize (can be multiple verses)
    public Scripture(string scritpure, string reference)
    {
        _scripture = scritpure;
        _reference = new Reference(reference);
        _words = new List<Word>();
        SplitVerseIntoWords();
    }

    private void SplitVerseIntoWords()
    {
        string[] _wordArray = _scripture.Split(' '); // split based on every space
        foreach(string _word in _wordArray)
        {
            _words.Add(new Word(_word)); // put a new Word class into the word list
        }
    }

    // prints the scripture with whatever is there as the words
    public void PrintScripture()
    {
        Console.Clear(); // clear the terminal
        PrintReference(); // put down the reference
        foreach(Word _word in _words)
        {
            Console.Write($"{_word.FullWord()} "); // print each word with a space after it
        }
        Console.WriteLine(); // new line
    }

    public void PrintReference()
    {
        Console.Write(_reference.GetReference() + " "); // list the reference with a space afterward
    }
    
    // every time this is called, a few words are blanked out, unitl it turns false when no more can be blanked out
    public bool PrintWithFewer()
    {
        if(blankedOut >= _words.Count)
        {
            return false; // all words have been blanked out already, end now
        }
        
        Random random = new Random();
        int _toWipeOut = 3; //blank out 3 words at a time
        
        while(_toWipeOut > 0 && blankedOut < _words.Count) // while we still need to blank out more, and if we haven't hit the max
        {
            int _index = random.Next(0,_words.Count);
            if(_words[_index].MakeBlank())
            {
                _toWipeOut -= 1; // one less word needed to blank out
                blankedOut ++; // if this word wasn't already blank, add one more blanked out word
            }
        }
        PrintScripture(); // now print the verses
        return true; // we can go another round
    }
}