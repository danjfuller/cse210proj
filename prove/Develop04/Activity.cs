

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

    // gets from user and sets the length for how long the activity will last
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
    }

    // starts the timer for your activity (sets the end time for it)
    public void StartTimer()
    {
        _endTime = DateTime.Now.AddSeconds(_seconds); // set an end time the declared seconds time from now
    }

    public void Start()
    {
        Console.Clear();
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
        Console.WriteLine($"You completed the {_name} Activity. You did this for {_seconds} seconds.");
        StallForSeconds(5);
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
        List<char> stallers = new List<char> {'-','\\','|','/'};
        for(int t = time*2; t > 0; t--)
        {
            Console.Write(stallers[t % stallers.Count]); // wrap through this list many times over again
            Thread.Sleep(500); // wait a half second (this is why we multiplied time by 2 at the start)
            Console.Write("\b \b"); // erase it
        }
    }

    // Counts down until you hit zero, then ends
    public void CountDown(int start)
    {
        for(int i = start; i > 0; i--)
        {
            Console.Write(i);
            Thread.Sleep(1000); // sleep for a second
            Console.Write("\b \b"); // remove the character, then loop again
        }
    }
}