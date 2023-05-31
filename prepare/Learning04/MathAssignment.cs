
class MathAssignment : Assignment
{
    private string _textbookSection;
    private string _problems;

    public MathAssignment(string name, string topic, string sectionNum, string problems) : base(name, topic)
    {
        _textbookSection = sectionNum;
        _problems = problems; 
    }

    // Gives a nice format of the homework assignment
    public string GetHomeworkList()
    {
        return $"Section {_textbookSection} Problems {_problems}";
    }
}