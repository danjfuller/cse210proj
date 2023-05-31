
class WritingAssignment : Assignment
{
    private string _title;

    public WritingAssignment(string name, string topic, string title) : base(name, topic)
    {
        _title = title;
    }

    // gives information on the writing assignment and who will write it
    public string GetWritingInformation()
    {
        return $"{_title} as written by {GetStudentName()}";
    }
}