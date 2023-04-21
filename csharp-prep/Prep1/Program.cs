using System;

class Program
{
    // Takes name from user and displays it in a James Bond style format
    static void Main(string[] args)
    {
        Console.Write("What is your first name? "); // get first and last name
        string firstName = Console.ReadLine();
        Console.Write("What is your last name? "); // take their answer in on the same line
        string lastName = Console.ReadLine();

        // display their name in a James Bond format, double-spaced from previous line
        Console.WriteLine($"\nYour name is {lastName}, {firstName} {lastName}.");
    }
}