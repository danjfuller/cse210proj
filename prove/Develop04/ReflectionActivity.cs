
class Reflection : Activity
{
    private List<string> _reflectionPrompts = new List<string>
    {
        "Think of a time when you stood up for someone else.",
        "Think of a time when you did something really difficult.",
        "Think of a time when you helped someone in need.",
        "Think of a time when you did something truly selfless."
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
        "How can you keep this experience in mind in the future?",
        "How could sharing this story change the outlook of others?"
    };

    public Reflection()
    {
        SetSummary("This activity will help you reflect on times in your life when you have shown strength and resilience. This will help you recognize the power you have and how you can use it in other aspects of your life.");
        SetName("Reflection");
    }

    // runs the show
    public void Begin()
    {
        Start();
        ShowPrompt();
        Console.WriteLine("When you have an idea and are ready, press enter.");
        Console.ReadLine(); // wait until they press enter
        Console.WriteLine("Reflect on the following questions about it:");
        Console.Write("Begin in: ");
        CountDown(4);
        StartTimer(); // time starts now
        Console.Clear(); // clear the console
        Random _random = new Random();
        List<int> _used = new List<int>();
        do 
        {
            int _promptNum = _random.Next(_secondaryQuestions.Count);
            if(_used.Count < _secondaryQuestions.Count) // if the prompts list isn't exhausted already
            {
                while(_used.Contains(_promptNum)) // if this one has already been used
                {
                    _promptNum = _random.Next(_secondaryQuestions.Count); // get a different one until it is a new one
                }
                _used.Add(_promptNum); // we have now used it
            }
            else
            {
                // they finished all of the questions, so tell them they finished
                Console.WriteLine("\nYou did all of the prompts. Think of a different time, and continue: \n");
                _used.Clear(); // clear the list, then we'll restart
                CountDown(5); // wait 5 seconds then go again...
            } 
            Console.Write(_secondaryQuestions[_promptNum]+" "); // give the prompt
            StallForSeconds(5);
            Console.WriteLine(""); // put the next question on the next line
        } while (!TimesUp()); // while time is not up, repeat
        Console.WriteLine(""); // space it out
        Finish();
    }

    public void ShowPrompt()
    {
        Console.Write("\n --- "); // space it out nicely
        Random _random = new Random(); // print a random prompt below
        Console.Write(_reflectionPrompts[_random.Next(_reflectionPrompts.Count)]);
        Console.WriteLine("--- \n");
    }
}