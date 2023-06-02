
class Reflection : Activity
{
    private List<string> _reflectionPrompts = new List<string>
    {

    };

    private List<string> _secondaryQuestions = new List<string>
    {
        "Why was this experience meaningful to you?",
        "Have you ever done anything like this before?",
        "How did you get started?",
        "How did you feel when it was complete?",
        "What made this time different than other times when you were not as successful?",
        "What is your favorite thing about this experience?",
        "What could you learn from this experience that applies to other situations?",
        "What did you learn about yourself through this experience?",
        "How can you keep this experience in mind in the future?"
    };

    public Reflection()
    {
        SetSummary("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        SetName("Reflection");
    }

    // runs the show
    public void ReflectionActivity()
    {
        Start();
        ShowPrompt();
        Console.WriteLine("When you have an idea and are ready, press enter.");
        Console.ReadLine(); // wait until they press enter
        Console.WriteLine("Reflect on the following questions about it:");
        Console.Write("Begin in: ");
        CountDown(4);
        do 
        {
            // > ask a random question
            StallForSeconds(5);
        } while (!TimesUp()); // while time is not up, repeat

        Finish();
    }

    public void ShowPrompt()
    {
        Console.Write("\n --- "); // space it out nicely
        Console.WriteLine("Random Prompt here");
        Console.WriteLine("--- \n");
    }
}