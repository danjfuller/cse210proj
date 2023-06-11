using System;

// Scripture Memorizer, by Daniel Fuller
// This memorizer blanks out 3 words at a time,and they are always new words, not ones already blanked out.
// In addition, this program prompts the user to choose from a list of unique verses to memorize.
class Program
{
    public static Scripture _scripture;
    
    public static List<Scripture> _allVerses= new List<Scripture>
    {
        new Scripture("Trust in the Lord with all thine heart; and lean not unto thine own understanding. In all thy ways acknowledge him, and he shall direct thy paths.", new Reference("Proverbs 3", 5, 6)),
        new Scripture("And we did magnify our office unto the Lord, taking upon us the responsibility, answering the sins of the people upon our own heads if we did not teach them the word of God with all diligence; wherefore, by laboring with our might their blood might not come upon our garments; otherwise their blood would come upon our garments, and we would not be found spotless at the last day.", new Reference("Jacob 1", 19)),
        new Scripture("Wherefore, I would speak unto you that are of the church, that are the peaceable followers of Christ, and that have obtained a sufficient hope by which ye can enter into the rest of the Lord, from this time henceforth until ye shall rest with him in heaven.", new Reference("Moroni 7", 3))
    };

    static void Main(string[] args)
    {
        RunMemorizer();
    }

    //This is code to get a verse to memorize, and then print a few words less every time you press enter
    static void RunMemorizer()
    {
        PromptForScripture(); // get the verse that they want to do
        Console.Clear();
        _scripture.PrintScripture();
        do // print the scripture
        {
            Console.WriteLine("\nPress Enter to continue, or type 'quit' to exit: ");
            string input = Console.ReadLine();
            if(input.Contains("quit") || input.Contains("Quit")) // if the user wants to end early,
            {
                break;
            }
        } while(_scripture.PrintWithFewer()); // do again with some words missing
    }

    // ask the user what scripture they want to practice...
    public static void PromptForScripture()
    {
        Console.Clear();
        Console.WriteLine("What scripture would you like to memorize? \n");
        int optionNumber = 0;
        foreach(Scripture _script in _allVerses)
        {
            Console.Write(optionNumber + "- ");
            _script.PrintReference();
            Console.WriteLine(""); // add a new line after
            optionNumber++;
        }
        Console.WriteLine(); // new line
        
        // get their choice
        bool _validChoice = false;
        do
        {
            Console.Write("Choice number: ");
            string choice = Console.ReadLine();
            for(int i=0; i < _allVerses.Count; i++)
            {
                if(int.TryParse(choice, out int num)) // if they give a valid number back
                {
                    if(num == i)
                    {
                        _scripture = _allVerses[i]; // they made a valid selection
                        _validChoice = true;
                    }
                }
            }
            if(choice == "") // if they just type enter, assign the default scripture
            {
                _scripture = _allVerses[0];
                _validChoice = true;
            }
            if(!_validChoice)
            {
                Console.WriteLine("Invalid Answer, try again. Or press enter to choose the default '0' verse.");
            }
        } while(!_validChoice); // go until we get a valid choice
    }
}
