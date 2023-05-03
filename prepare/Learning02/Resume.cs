using System;

public class Resume
{
    public string _name; // who this is the resume for
    public List<Job> _jobs = new List<Job>(); // their list of jobs

    public void DisplayResume()
    {
        Console.WriteLine($"Name: {_name}"); // give formatting to the naming system
        Console.WriteLine("Jobs:");
        foreach(Job job in _jobs)
        {
            job.PrintJob(); // print each job from the resume, one at a time
        }
    }
}