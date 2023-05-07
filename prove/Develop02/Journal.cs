using System;

public class Journal
{
    public List<Entry> entries;
    public Journal()
    {
        entries = new List<Entry>(); // initialize the entries variable
    }

    // displays journal in a nice format
    public void Display()
    {
        foreach(Entry entry in entries)
        {
            entry.Display();
            Console.WriteLine(""); // put an empty line down beneath it
        }
    }
}