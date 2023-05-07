using System;

class Program
{
    public static List<string> prompts = new List<string>
    { // multiple different prompts for users to respond to
        "What was my favorite meal today?",
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What parts of town did I park my car at today?",
        "Who did I have a good conversation with today?",
        "What was really worth my time that I did today?"
    };

    static Journal myJournal;

    static void Main(string[] args)
    {
        myJournal = new Journal(); // get our journal ready
        Welcome();
        
        MainMenu();
        while(ChooseFileOption()) // then have them choose an option, and keep looping until they say to quit
        {
            MainMenu(); // show the menu again
        }
    }

    // give a greeting
    static void Welcome()
    {
        Console.WriteLine("Welcome to The Handy Journal v1.0");
    }

    // shows each different menu option
    static void MainMenu()
    {
        Console.WriteLine("Choose an option:");
        Console.WriteLine("1   Write a new Entry");
        Console.WriteLine("2   Display My Journal");
        Console.WriteLine("3   Save the Journal");
        Console.WriteLine("4   Load a Journal");
        Console.WriteLine("5   Quit");
    }

    // Has user choose a file option, returns false if they want to quit
    static bool ChooseFileOption()
    {
        Console.Write("What is your choice? ");
        string choice = Console.ReadLine();
        switch (choice)
        {
            case "1":
                NewPromptEntry(); // let them write a new journal entry
                break;
            case "2":
                myJournal.Display(); // show their current journal entries from this session
                break;
            case "3":
                Save(); // save the journal
                break;
            case "4":
                Load(); // load a Journal
                break;

            default: // if the case they give is not any of the above:
                if(choice == "5" || choice == "quit" || choice == "Quit") // and they are not quitting...
                {
                    // let them proceed to quit
                }
                else // they did the wrong command
                {
                    Console.WriteLine("Command not recognized. Try again, pressing either 1,2,3,4 or 5.");
                    Console.WriteLine("Or type \"Quit\" to exit the program");
                }
                break;
        }
        if(choice == "5" || choice == "quit" || choice == "Quit")
        {
            return false; // let them quit
        }
        else
        {
            return true; // show menu again, and keep going
        }
    }

    // adds a new user entry to the journal
    static void NewPromptEntry()
    {
        Random random = new Random(); // get a random number maker
        int promptNum = random.Next(0, prompts.Count); // get a random number corresponding to a prompt

        // make a new entry, and prompt them to fill it
        Entry entry = new Entry(prompts[promptNum], PromptEntry(promptNum));
        myJournal.entries.Add(entry); // add it to our current journal
    }

    // get response to the chosen journal prompt number
    static string PromptEntry(int promptNum)
    {
        Console.WriteLine(prompts[promptNum]);
        return Console.ReadLine(); // return their journal response
    }

    // has user save their file
    static void Save()
    {
        Console.WriteLine("What file name should this be saved as? ");
        SaveJournal(Console.ReadLine());
    }

    // Saves the current journal at specified fileName
    static void SaveJournal(string fileName)
    {
        // some code in case the file exists already to confirm overwriting it
        using (System.IO.StreamWriter writer = new StreamWriter(fileName)) // only exist inside this scope to prevent bugs
        {
            foreach(Entry entry in myJournal.entries)
            {
                writer.WriteLine(entry.Save()); // save the file as one line
            }
        }
    }

    // has user load their chosen journal file
    static void Load()
    {
        Console.WriteLine("What Journal file name do you want to load?");
        LoadJournal(Console.ReadLine());
    }

    // turns the journal from a given file to a readable Journal class
    static void LoadJournal(string fileName)
    {
        if(!System.IO.File.Exists(fileName))
        {
            Console.WriteLine("This file does not exist. Try again."); // this file does not exist
            return; // exit this finction, and show the menu again
        }
        myJournal = new Journal(); // do a breand new journal
        string[] lines = System.IO.File.ReadAllLines(fileName);
        for(int l = 0; l < lines.Length; l++) // each line is a fileName
        {
            string[] parts = lines[l].Split("~|~"); // split up each line
            string date = parts[0];
            string question = parts[1];
            string inputText = parts[2];
            Entry entry = new Entry(question, inputText, date); // make a new entry
            myJournal.entries.Add(entry);
        }
    }
}