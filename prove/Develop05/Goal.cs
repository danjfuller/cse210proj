class Goal
{
    private int _points;
    private bool _isComplete;
    protected string _name;
    protected string _description;

    public Goal(string name, string descrip)
    {
        _name = name;
        _description = descrip;
        _isComplete = false;
    }

    // Saves this object's information as a ~|~ separated string
    public virtual string Save()
    {
        return $"{_isComplete}~|~{_name}~|~{_description}~|~{_points}";
    }

    // loads a string to make the data of this object
    public virtual void Load(string info)
    {
        string[] sections = info.Split("~|~");
        int s = 0;
        if(sections.Length > 4)
        {
            s++; // make s start at 1 if this is a special type of goal
        }
        _isComplete = bool.Parse(sections[s]);
        _name = sections[s+1];
        _description = sections[s+2];
        _points = int.Parse(sections[s+3]);
    }

    // contains additional instructions for setup of the goal
    public virtual void SetUp()
    {
        Console.Write("What is the ammount of points to associate with accomplishing this goal?");
        string pointString = Console.ReadLine();
        int point = int.Parse(pointString);
        _points = point; // save the point value
    }

    // prints the name out
    public void PrintName()
    {
        Console.Write(_name);
    }

    // Shows the user their progress on their goals
    public virtual void PrintProgress()
    {
        string check = (_isComplete) ? "X" : " ";
        Console.Write($"[{check}] ");
        Console.Write(_name);
        Console.Write($" ({_description})");
    }

    public void MarkComplete()
    {
        _isComplete = true;
    }

    // sets the points for completing this goal
    public void SetPoints(int pointValue)
    {
        _points = pointValue;
    }
}