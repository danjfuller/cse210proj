using System;

class Program
{
    static void Main(string[] args)
    {
        Job job1 = new Job(); // create 2 new job classes
        Job job2 = new Job();

        job1._company = "Intel"; // give data to each job type
        job1._jobTitle = "Senior Software Engineer";
        job1._startYear = 1982;
        job1._endYear = 2004;
        job2._company = "Microsoft"; // second job's data
        job2._jobTitle = "UX Quality Assurance Specialist";
        job2._startYear = 1837;
        job2._endYear = 2009;

        Resume resume = new Resume(); // make a resume to hold all the job data
        resume._name = "John Brown";
        
        resume._jobs.Add(job1); // add jobs to the resume
        resume._jobs.Add(job2);

        resume.DisplayResume(); // show the resume
    }
}