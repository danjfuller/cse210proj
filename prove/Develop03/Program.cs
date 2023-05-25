using System;

class Program
{
    public static Scripture _scripture;
    public static bool _finished;
    
    static void Main(string[] args)
    {
        Console.WriteLine("Hello Develop03 World!");
        RunMemorizer();
    }

    static void RunMemorizer()
    {
        _scripture = new Scripture();
        _finished = false;
        Console.Clear();
        _scripture.PrintScripture();
        Console.WriteLine("Press Enter to continue: ");
        Console.ReadLine(); // wait for them to continue
        while(_scripture.PrintWithFewer()) // print the scripture with some words missing
        {
            Console.WriteLine("Press Enter to continue: ");
            Console.ReadLine();
        }
    }
}