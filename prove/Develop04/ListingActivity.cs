
class Listing : Activity
{
    private List<string> _prompts = new List<string>
    {
        "Who are people that you appreciate?",
        "What are personal strengths of yours?",
        "Who are people that you have helped this week?",
        "When have you felt the Holy Ghost this month?",
        "Who are some of your personal heroes?",
        "What people do you aspire to be like?"
    };

    // number of user inputs made during time
    private int _userInputs;

    public Listing()
    {
        SetSummary("This activity will help you reflect on the good things in your life by having you list as many things as you can in a certain area.");
        SetName("Listing");    
    }

    public void Begin()
    {
        Start();
        Console.WriteLine("List as many responses as you can to this prompt:");

        // show random prompt
        Console.Write("\n --- "); // space it out nicely
        Random _random = new Random(); // print a random prompt below
        Console.Write(_prompts[_random.Next(_prompts.Count)]);
        Console.WriteLine("--- \n");
        // reuse the prompt formatting from the reflection class
        Console.Write("Begin in: ");
        CountDown(4);
        StartTimer(); // clock is ticking now
        Console.WriteLine("");
        do
        {
            Console.Write("> "); // indent for their response
            Console.ReadLine(); // have them give a response, but we don't need to save it
            
            _userInputs ++;
        } while(!TimesUp());
        // print out how many they listed
        Console.WriteLine($"\nYou listed {_userInputs} items!\n");
        Finish();
    }

}