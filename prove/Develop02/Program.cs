using System;
using System.Text.Json;

/********************************************************
* Author: Daniel Fuller, May 13, 2023
* 
* This Program helps you keep a Journal. In addition, I
* added that the journal is saved as a JSON file, and I 
* have included extra error-checking for that and for 
* user's terminal commands.
********************************************************/
class Program
{
    // multiple different prompts for users to respond to
    public static List<string> prompts = new List<string>
    {
        "What was my favorite meal today?",
        "Who was the most interesting person I interacted with today?",
        "What was the best part of my day?",
        "What parts of town did I park my car at today?",
        "Who did I have a good conversation with today?",
        "What was really worth my time that I did today?"
    };

    static Journal _myJournal; // The current Journal class being used

    static void Main(string[] args)
    {
        _myJournal = new Journal(); // get our journal ready, starting blank
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
                _myJournal.Display(); // show their current journal entries from this session
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
        _myJournal._entries.Add(entry); // add it to our current journal
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
        Console.WriteLine("Who will this Journal be saved for? ");
        string saveName = Console.ReadLine();
        SaveJournal(saveName);
    }

        // Saves the current journal at specified fileName.json
    static void SaveJournal(string fileName)
    {
        _myJournal._title = fileName; // identify inside the file who owns it
        using (System.IO.StreamWriter writer = new StreamWriter(fileName + ".json")) // only exist inside this scope to prevent bugs
        {
            var options = new JsonSerializerOptions { WriteIndented = true }; // write the json save file nicely indented
            string json = JsonSerializer.Serialize(_myJournal, options); // convert this class into a json format
            writer.WriteLine(json); // save to a file

            Console.WriteLine($"Saved as {fileName}.json"); // inform the user of our doing it
        }
    }

    // has user load their chosen journal file
    static void Load()
    {
        Console.WriteLine("Who's Journal name do you want to load? (as a .json)");
        LoadJournal(Console.ReadLine());
    }

    // turns the journal from given fileName.json to a readable Journal class
    static void LoadJournal(string fileName)
    {
        fileName = fileName.Replace(".txt", ".json"); // turn any text files into a json file, or else we can't read it
        if(!System.IO.File.Exists(fileName)) // if the file does not exist
        {
            if(System.IO.File.Exists(fileName + ".json")) // try once again with fileName extension added at end
            {
                fileName = fileName + ".json"; // if that works, then add extension to end of fileName
            }
            else
            {
                Console.WriteLine("This file does not exist. Try again."); // else this file does not exist
                return; // exit this function, and show the menu again
            }
        }

        try // try to load the file, and inform user of any errors while doing so
        {
            string jsonText = System.IO.File.ReadAllText(fileName); // read file
            _myJournal = JsonSerializer.Deserialize<Journal>(jsonText)!; // '!' at end allows the return to be null
        }
        catch
        {
            Console.WriteLine("Error reading JSON File. Try fixing with a separate text editor");
            _myJournal = new Journal(); // make a blank journal like at the start of the program
        }
        
        if(_myJournal == null) // if the journal is blank...
        {
            Console.WriteLine("File Loading failed due to incompatible or empty text format"); // say that this file didn't load properly
            _myJournal = new Journal(); // then make a new journal, like it was at the start of the program
        }

        /***************************************************************************
        * 1.0 older loading format
        ****************************************************************************
        string[] lines = System.IO.File.ReadAllLines(fileName);
        for(int l = 0; l < lines.Length; l++) // each line is a fileName
        {
            string[] parts = lines[l].Split("~|~"); // split up each line
            string date = parts[0];
            string question = parts[1];
            string inputText = parts[2];
            Entry entry = new Entry(question, inputText, date); // make a new entry
            myJournal._entries.Add(entry);
        }
        */
    }
}