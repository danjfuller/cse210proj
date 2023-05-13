using System.Text.Json;

public class Journal
{
    public string _title {get; set;} // have a title of the JSON File
    public List<Entry> _entries {get; set;}
    public Journal()
    {
        _entries = new List<Entry>(); // initialize the entries variable
    }

    // displays journal in a nice format
    public void Display()
    {
        foreach(Entry entry in _entries)
        {
            entry.Display();
            Console.WriteLine(""); // put an empty line down beneath it
        }
    }
}