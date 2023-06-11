
class Breathing : Activity
{
    public Breathing()
    {
        SetSummary("This activity will help you relax. You will be breathing in and out slowly.");
        SetName("Breathing");
    }

    // starts the activity
    public void Begin()
    {
        Start();
        StartTimer(); // time starts now
        Console.WriteLine(""); // give some initial space for the activity
        while(!TimesUp())
        {
            Console.Write("Breathe in...");
            CountDown(4);
            Console.Write("\n"); // new line
            Console.Write("Now breathe out...");
            CountDown(4);
            Console.WriteLine("\n"); // double new line
        }
        Finish();
    }

}