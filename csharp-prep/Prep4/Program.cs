using System;

class Program
{
    static void Main(string[] args)
    {
        List<int> numbers = new List<int>();
        int num = 0; // set a default
        Console.WriteLine("Enter a list of numbers, type 0 when finished.");
        do
        {
            Console.Write("Enter number: ");
            num = int.Parse(Console.ReadLine()); // take in an integer
            if(num != 0)
            {
                numbers.Add(num); // add numbers to the list until they enter 0
            }
        } while (num != 0);
        
        int total = 0;
        int lowest = numbers.Max(); // take the highest positive number
        foreach(int n in numbers)
        {
            total += n; // add up each number
            if(n > 0 && n < lowest) // if n is positive, and is less than the highest number
            {
                lowest = n; // make it the lowest number
            }
        }
        Console.WriteLine($"The sum is: {total}");
        Console.WriteLine($"The average is: {((float)numbers.Average())}"); // use built-in functions of the list class
        Console.WriteLine($"The largest number is: {numbers.Max()}");
        if(lowest > 0) // if we actually have a positive number as the value of this variable...
        {
            Console.WriteLine($"The smallest positive number is: {lowest}");
        }
        numbers.Sort();
        Console.WriteLine("The sorted list is:");
        foreach(int n in numbers)
        {
            Console.WriteLine(n);
        }
    }
}