using System;

class Program
{
    // lists 3 different example assignments using inheritance for the second two
    static void Main(string[] args)
    {
        Assignment assignment = new Assignment("Dan", "Liturgical Analysis");
        Console.WriteLine(assignment.GetSummary());

        MathAssignment assignment1 = new MathAssignment("Dan", "Euler's Demise", "2.8", "9-23");
        Console.WriteLine(assignment1.GetSummary());
        Console.WriteLine(assignment1.GetHomeworkList());

        WritingAssignment assignment2 = new WritingAssignment("Dan", "General Research Paper", "Misconceptions about Aeronautical Methods");
        Console.WriteLine(assignment2.GetSummary());
        Console.WriteLine(assignment2.GetWritingInformation());

    }
}