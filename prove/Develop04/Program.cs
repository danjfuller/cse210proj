using System;

// This program exceeds requirements by adding robust error checking
class Program
{
    // A program to help you practice mindfullness with 3 different exercies
    static void Main(string[] args)
    {
        Console.Clear();
        DisplayMenu();
        while(ChooseActivity()) // let user keep choosing activities until they quit
        {
            DisplayMenu();
            
        }
    }
    
    // writes the menu on terminal
    public static void DisplayMenu()
    {
        Console.WriteLine("Menu Options:");
        Console.WriteLine("   1. Breathing Activity");
        Console.WriteLine("   2. Reflecting Activity");
        Console.WriteLine("   3. Listing Activity");
        Console.WriteLine("   4. Quit");
    }

    // has user choose an option, and if they want to continue this application
    public static bool ChooseActivity()
    {
        Console.Write("Select an option: ");
        string choice = Console.ReadLine();
        bool _continue = true;
        switch(choice)
        {
            case "1":
                Breathing _breathing = new Breathing();
                _breathing.Begin(); // start the breathing activity
                break;
            case "2":
                Reflection _reflection = new Reflection();
                _reflection.Begin(); // begin reflection activity
                break;
            case "3":
                Listing _listing = new Listing();
                _listing.Begin(); // begin listing activity
                break;
            case "4":
            case "quit":
            case "Quit":
            // they wish to quit, so end the program
                _continue = false;
                break;
            default:
                Console.WriteLine("Invalid command. Try pressing 1, 2, 3, or 4, or just type 'quit'");
                break;
        }

        return _continue;
    }
}