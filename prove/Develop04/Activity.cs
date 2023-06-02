

class Activity
{
    private int _seconds;
    private string _summary;
    
    // the name of this activity
    private string _name;

    private DateTime _endTime;

    public Activity()
    {
        
    }

    public void SetSummary(string summary)
    {
        _summary = summary;
    }

    public void SetName(string name)
    {
        _name = name;
    }

    // states the activity with a new line afterward
    private void StateActivity(string activity)
    {
        Console.WriteLine($"Welcome to the {activity} Activity.\n");
    }

    // sets how long the activity will last
    private void PromptForSeconds()
    {
        do
        {
            Console.Write("How long would you like the activity to go for, in seconds? ");
            try
            {
                _seconds = int.Parse(Console.ReadLine());
            }
            catch
            {
                _seconds = -1; // they gave a bad value, so give a default
            }
            if(_seconds < 0)
            {
                Console.WriteLine("Invalid Input. Try again, typing only a number. ");
            }
        }
        while(_seconds < 0);
        _endTime = DateTime.Now.AddSeconds(_seconds); // set an end time a cartain distance from now
    }

    public void Start()
    {
        StateActivity(_name);
        Console.WriteLine(_summary);
        Console.WriteLine("");
        PromptForSeconds();
        Console.Clear();
        Console.WriteLine("Get Ready...");
        StallForSeconds(4); // wait, then begin the activity
    }

    // congratulates the user, tell them how much time they took in the specific activity
    public void Finish()
    {
        Console.WriteLine("Great Job!\n");
        StallForSeconds(3); // wait
        Console.WriteLine($"You completed the {_name} Activity. Time was {_seconds} seconds.");
        StallForSeconds(3);
        Console.Clear(); // clear the console for next program
    }

    // tells you if the time is now up
    public bool TimesUp()
    {
        return DateTime.Now > _endTime; // if we passed the end time, return true
    }

    // shows an animation to stall the time out until it finishes
    public void StallForSeconds(int time)
    {
        Console.WriteLine("stalling...");
        Thread.Sleep(250); // wait a quarter second
        Console.Write("\b\b"); // erase the character
    }

    // Counts down until you hit zero, then ends
    public void CountDown(int start)
    {
        Console.WriteLine(start);
        Thread.Sleep(1000); // sleep for a second
    }
}