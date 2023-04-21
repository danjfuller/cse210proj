using System;

class Program
{
    // take in a user percentage, then determine the Letter grade from it
    static void Main(string[] args)
    {
        Console.Write("What is your grade percantage? ");
        string textPercent = Console.ReadLine(); // store input as text
        int percentage = int.Parse(textPercent); // convert to int
        string letterGrade;
        if(percentage >= 90)
        {
            letterGrade = "A";
        }
        else if(percentage >= 80)
        {
            letterGrade = "B";
        }
        else if(percentage >= 70)
        {
            letterGrade = "C";
        }
        else if(percentage >= 60)
        {
            letterGrade = "D";
        }
        else
        {
            letterGrade = "F";
        }

        if(percentage < 97 && percentage >=60) // no A+, and no F+ or F- (grade must be between 60 to 96)
        {
            if(percentage % 10 >= 7) // if last integer is 7 or above, that is a +
            {
                letterGrade += "+";
            }
            else if(percentage % 10 < 3) // if last integer is below 3, that is a -
            {
                letterGrade += "-";
            }
        }
        Console.WriteLine(letterGrade); // give the user their letter Grade

        if(percentage >= 70) // if the percentage is 70 or above, then tell them they passed it
        {
            Console.WriteLine("You Passed the class!");
        }
        else
        {
            // if not, then give encouragement to try again next time!
            Console.WriteLine("Try again next time, and you could pass the class!"); // give encouragement
        }
    }
}