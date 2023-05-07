using System;

public class Entry
{
    string date; // keep these all private for now
    string prompt;
    string response;

    // a constructor for the entry, inputting response and date and prompt into the class
    public Entry(string question, string inputText)
    {   
        prompt = question;
        response = inputText;
        date = System.DateTime.Now.ToShortDateString(); // input date as a string
    }

    // a constructor for entry, taking in a date value, also
    public Entry(string question, string inputText, string time)
    {   
        prompt = question;
        response = inputText; // map inputs to the class variables
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
        return $"{date}~|~{prompt}~|~{response}"; 
    }
}