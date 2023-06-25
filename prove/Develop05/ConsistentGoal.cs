class ConsistentGoal : Goal
{
    public ConsistentGoal(string name, string descrip) : base(name, descrip)
    {

    }

    public override string Save()
    {
        return "Eternal~|~"+ base.Save(); // save this goal type
    }

    public override int MarkComplete()
    {
        return GetPointValue(); // the goal will never be completed. Just give them their point values they earned
    }

    public override void PrintProgress()
    {
        base.PrintProgress();
    }

}