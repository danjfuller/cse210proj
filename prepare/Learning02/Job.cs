using System;

public class Job
{
    public string _company; // what company they worked for
    public string _jobTitle; // what their job was to do
    public int _startYear; // dates as integers (the year number)
    public int _endYear;

    public void PrintJob() // prints a nicely formatted job details line
    {
        Console.WriteLine($"{_jobTitle} ({_company}) {_startYear}-{_endYear}");
    }

}