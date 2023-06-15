public abstract class Shape
{
    private string _color;

    public Shape(string color)
    {
        _color = color;
    }

    public string GetColor()
    {
        return _color;
    }

    // the assignment instructions ask for this, though it doesn't ever need to get used.
    public void SetColor(string color)
    {
        _color = color;
    }

    // This GetArea() does not need to be virtual, as it has no realistic default
    // So we make it abstract instead 
    public abstract double GetArea();
}