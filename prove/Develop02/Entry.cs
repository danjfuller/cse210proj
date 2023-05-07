using System;

public class Entry
{
    string date;
    string prompt;
    public string response;

    // a constructor for the entry, inputting response and date and prompt into the class
    public Entry(string question, string inputText)
    {   
        prompt = question;
        response = inputText;
        date = System.DateTime.Now.ToString(); // input date as a string
    }

    // a constructor for entry, taking in a date value, also
    public Entry(string question, string inputText, string time)
    {   
        prompt = question;
        response = inputText;
        date = time;
    }

    // displays the entry, nicely formatted
    public void Display()
    {
        Console.WriteLine($"Date: {date} -- Prompt: {prompt}");
        Console.WriteLine(response);
    }

    // gives a savefile-friendly version of this entry
    public string Save()
    {
        return date + "\n" + prompt;
    }
}