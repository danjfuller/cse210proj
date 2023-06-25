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
        if(sections.Length < 8) // we need to have at least 7 data items in this array
        {
            _progress = 0;
            _numTimes = 1;
            _pointForFinish = 0;
            Console.WriteLine("Error loading checklist goal. Progress Values set to defaults");
            return;
        }
        _progress = int.Parse(sections[5]);
        _numTimes = int.Parse(sections[6]);
        _pointForFinish = int.Parse(sections[7]);
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
        if(!int.TryParse(Console.ReadLine(), out int num))
        {
            Console.Write("Invalid number. Default value of 5 was chosen");
            _numTimes = 5; // save the point value
        }
        else
        {
            _numTimes = num; // save the point value
        }
        Console.Write("What is a bonus points amount for accomplishing this goal that many times? ");
        if(!int.TryParse(Console.ReadLine(), out int finalPoint))
        {
            Console.Write("Invalid number. Default value of 50 was chosen");
            _pointForFinish = 50; // save the point value
        }
        else
        {
            _pointForFinish = finalPoint; // save the point value
        }
    }

    public override int MarkComplete()
    {
        if(IsComplete())
        {
            return base.MarkComplete(); // give them the same message as the base class when finished
        }
        else
        {
            _progress++; // nice job!
            if(_progress >= _numTimes)
            {
                base.MarkComplete(); // have the base class mark itself as finished (ignore it's return value)
                return _pointForFinish; // they did the goal!
            }
            else
            {
                return GetPointValue();
            }
        }
    }
}