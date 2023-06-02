
class Listing : Activity
{
    private List<string> _prompts = new List<string>
    {

    };

    // number of user inputs made during time
    private int _userInputs;

    public Listing()
    {
        SetSummary("List as many responses as possible to the following question");
        SetName("Listing");    
    }

    public void ListingActivity()
    {
        Start();
        // show random prompt to user
        // reuse the prompt formatting from the reflection class
        CountDown(4);
        do
        {
            Console.WriteLine("> "); // indent for their response
            Console.ReadLine(); // have them give a response, but we don't need to save it
            // Tell them to keep listing items
            _userInputs ++;
        } while(!TimesUp());
        // print out how many they listed
        Finish();
    }

}