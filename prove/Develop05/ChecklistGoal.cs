class ChecklistGoal : Goal
{
    private int _numTimes; // the number of times to do the goal
    private int _progress;
    private int _pointForFinish;

    public ChecklistGoal(string name, string descrip) 
    : base(name, descrip)
    {
        _progress = 0;
    }

    public override string Save()
    {
        return "Checklist~|~" + base.Save() + "~|~" + _progress + "~|~" + _numTimes + "~|~" + _pointForFinish;
    }

    public override void Load(string info)
    {
        base.Load(info);
        string[] sections = info.Split("~|~");
        if(sections.Length < 7) // we need to have at least 7 data items in this array
        {
            _progress = 0;
            _numTimes = 1;
            _pointForFinish = 0;
            Console.WriteLine("Error loading checklist goal. Progress Values set to defaults");
            return;
        }
        _progress = int.Parse(sections[4]);
        _numTimes = int.Parse(sections[5]);
        _pointForFinish = int.Parse(sections[6]);
    }

    // show their progress on this goal
    public override void PrintProgress()
    {
        base.PrintProgress();
        Console.Write($" -- Currently Completed: {_progress}/{_numTimes}");
    }

    // get the number of times that they should accomplish this, and the bonus for doing so
    public override void SetUp()
    {
        base.SetUp(); // do the standard setup first
        Console.Write("How many times should this goal be accomplished? ");
        _numTimes = int.Parse(Console.ReadLine()); // convert to a number
        Console.Write("What is a bonus points amount for accomplishing this goal that many times? ");
        _pointForFinish = int.Parse(Console.ReadLine()); // get the points for completing
    }
}