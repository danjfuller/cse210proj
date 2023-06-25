using System;
using System.Text.Json;

// This program keeps track of goals and awards points for achieving them
// Extra work added was robust error checking of the program to prevent
// the user from causing errors in the program
class Program
{
    public static List<Goal> _goals;
    public static int _totalPoints;
    
    static void Main(string[] args)
    {
        Console.Clear();
        _goals = new List<Goal>();
        _totalPoints = 0;
        do
        {
            PrintPoints(); // show their total points
        } while(ChooseOption());
    }

    // lets the user choose an option. returns true if they want to continue.
    static bool ChooseOption()
    {
        Console.WriteLine("Goals Menu:");
        Console.WriteLine("  1. Create New Goal");
        Console.WriteLine("  2. List Goals");
        Console.WriteLine("  3. Save Goal List");
        Console.WriteLine("  4. Load My Goals");
        Console.WriteLine("  5. Record Goal Progress");
        Console.WriteLine("  6. Quit");
        Console.Write("What is your choice?: ");
        string choice = Console.ReadLine();
        switch(choice)
        {
            case "1":
                while(ChooseGoal()); // have them choose a goal until they decide to go back.
                break;
            case "2":
                ShowGoalList(); // show the goals
                break;
            case "3":
                Console.Write("What name should this be saved as (.txt)? ");
                SaveGoals(Console.ReadLine());
                break;
            case "4":
                Console.Write("What goal list should be loaded? ");
                _goals = LoadGoals(Console.ReadLine());
                break;
            case "5":
                ReportProgress();
                break;
            case "6":
            case "quit":
            case "Quit":
            case "exit":
            case "Exit":
                return false; // exit the loop
        }

        return true; // if they don't want to exit, then return true.
    }

    static void PrintPoints()
    {
        Console.WriteLine($"\nYou have {_totalPoints} points.\n");
    }

    // gives menu and options to create a new goal. Returns true if user wants to try it again.
    static bool ChooseGoal()
    {
        Console.WriteLine("Great! Choose one of these goal types:");
        Console.WriteLine("  1. Simple Goal");
        Console.WriteLine("  2. Eternal (Consistent) Goal");
        Console.WriteLine("  3. Checklist Goal");
        Console.Write("Your choice number (or type \"Back\" to cancel): ");
        string type = Console.ReadLine();
        switch(type)
        {
            case "1":
            case "2":
            case "3":
                int num = int.Parse(type);
                SetUpGoal(num); // a valid goal type needs to be set up now
                return false; // They made the goal, so we are done here
                
            case "quit":
            case "Quit":
            case "exit":
            case "Exit":
            case "back":
            case "Back":
                return false; // they want to go back to main menu
                
            default:
                Console.WriteLine("Invalid answer, please type 1,2,3, or \"Back\".");
                break;
        }
        return true; // they didn't choose a valid goal
    }

    // gets the name and description of each goal. Sets it up.
    static void SetUpGoal(int type)
    {
        Console.Write("What is the name of this goal?: ");
        string _name = Console.ReadLine();
        Console.Write("What is a short description of it?: ");
        string _description = Console.ReadLine();
        Goal goal;
        switch(type)
        {
            case 2:
                goal = new ConsistentGoal(_name, _description);
                break;
            case 3:
                goal = new ChecklistGoal(_name, _description);
                break;
            default:
                goal = new Goal(_name, _description);
                break; // technically, this should be no option other than option "1", but we'll assign this as the default anyway.
        }
        goal.SetUp(); // get the special points value for this goal
        _goals.Add(goal); // add this to the goal list
    }

    // prints out numbered, progress-counting, list of goals
    static void ShowGoalList()
    {
        Console.WriteLine("Your Goals are:");
        for(int g = 0; g < _goals.Count; g++)
        {
            Console.Write($"{g+1}. "); // number each goal from 1 to end amount
            _goals[g].PrintProgress(); // have them print their progress
            Console.WriteLine(""); // new line
        }
    }

    static void ReportProgress()
    {
        Console.WriteLine("The Goals are:");
        for(int g = 0; g < _goals.Count; g++)
        {
            Console.Write($"  {g+1}. ");
            _goals[g].PrintName();
            Console.WriteLine("");
        }
        Console.Write("Which Goal did you do? ");
        if(!int.TryParse(Console.ReadLine(), out int report) || report - 1 > _goals.Count)
        {
            Console.Write("Invalid. No changes made.");
        }
        else
        {
            int points = _goals[report-1].MarkComplete();
            Console.WriteLine($"You Earned {points} Points!");
            _totalPoints += points; // get the user their increased points
        }
    }

    static void SaveGoals(string fileName)
    {
        if(!fileName.EndsWith(".txt"))
        {
            fileName += ".txt"; // make sure it is saved as a text file
        }
        using (System.IO.StreamWriter writer = new StreamWriter(fileName)) // only exist inside this scope to prevent bugs
        {
            writer.WriteLine($"Goal Total :{_totalPoints}");
            foreach(Goal goal in _goals)
            {
                writer.WriteLine(goal.Save()); // save to a file
            }
            Console.WriteLine($"Saved as {fileName}"); // inform the user of our doing it
        }
    }

    static List<Goal> LoadGoals(string fileName)
    {
        List<Goal> loadedGoals = new List<Goal>();
        if(!System.IO.File.Exists(fileName)) // if the file does not exist
        {
            if(System.IO.File.Exists(fileName + ".txt")) // try once again with fileName extension added at end
            {
                fileName = fileName + ".txt"; // if that works, then add extension to end of fileName
            }
            else
            {
                Console.WriteLine("This file does not exist. Try again."); // else this file does not exist
                return null; // exit this function, and show the menu again
            }
        }
        try // try to load the file, and inform user of any errors while doing so
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            if(lines.Length < 2)
            {
                Console.WriteLine("No saved goals in this file, or file is missing total points value");
                return null; // there are no saved goals so far
            }
            _totalPoints = int.Parse(lines[0].Split(":")[1]); // grab the second item of the first line
            for(int l = 1; l < lines.Length; l++) // each line is a goal, except the first line
            {
                Goal loadedGoal;
                string[] parts = lines[l].Split("~|~"); // split up each line
                if(parts[0] == "Eternal") // The first part will tell us what kind of goal to load
                {
                    loadedGoal = new ConsistentGoal("null","null"); // we'll fill these in later
                }
                else if(parts[0] == "Checklist")
                {
                    loadedGoal = new ChecklistGoal("null","null");
                }
                else // its just a basic goal
                {
                    loadedGoal = new Goal("null","null");
                }
                loadedGoal.Load(lines[l]);
                loadedGoals.Add(loadedGoal);
            }
        }
        catch
        {
            Console.WriteLine("Error reading text File. Try fixing with a separate text editor");
            loadedGoals =  new List<Goal>(); // make a blank list like at the start of the program
        }
        
        if(loadedGoals == null) // if the goal list is blank...
        {
            Console.WriteLine("The loaded goal list is blank..."); // say that this file didn't load properly
            loadedGoals =  new List<Goal>(); // make a blank list like at the start of the program
        }
        return loadedGoals; // here's the list of loaded Goals
    }
}