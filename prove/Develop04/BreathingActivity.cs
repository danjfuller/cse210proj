
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
        while(!TimesUp())
        {
            Console.Write("\nBreathe in...");
            CountDown(4);
            Console.WriteLine("Breathe out...");
            CountDown(4);
        }
        Finish();
    }

}