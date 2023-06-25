class ConsistentGoal : Goal
{
    public ConsistentGoal(string name, string descrip) : base(name, descrip)
    {

    }

    public override string Save()
    {
        return "Eternal~|~"+ base.Save(); // save this goal type
    }

    public override void PrintProgress()
    {
        base.PrintProgress();
    }

}