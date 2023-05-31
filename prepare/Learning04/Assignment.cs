
class Assignment
{
    private string _studentName;
    private string _topic;

    public Assignment(string name, string topic)
    {
        _studentName = name;
        _topic = topic;
    }

    // gives a formatted summary of assignment
    public string GetSummary()
    {
        return $"{_studentName} - {_topic}";
    }

    // Name of the student
    public string GetStudentName()
    {
        return _studentName;
    }
}