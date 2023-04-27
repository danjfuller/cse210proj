using System;

class Program
{
    //takes and politely gives the square of user's favorite number
    static void Main(string[] args)
    {
        DisplayWelcome();
        string name = PromptUserName(); // get their name
        int num = PromptUserNumber();
        num = SquareNumber(num); // replace the number with its square
        DisplayResult(name, num); // show them the result
    }

    // gives a nice message
    static void DisplayWelcome()
    {
        Console.WriteLine("Welcome to this Program!");
    }

    //Gets the user's name as a string
    static string PromptUserName()
    {
        Console.Write("Please enter your name: ");
        return Console.ReadLine(); // give back their answer
    }

    // asks for the user's favorite number and returns it
    static int PromptUserNumber()
    {
        Console.Write("Please enter your favorite number: ");
        return int.Parse(Console.ReadLine()); // turn response into an int
    }

    // squares a number
    static int SquareNumber(int number)
    {
        return number * number;
    }

    //Displays the user's favorite number squared
    static void DisplayResult(string userName, int square)
    {
        Console.WriteLine($"{userName}, your favorite number squared is {square}");
    }
}