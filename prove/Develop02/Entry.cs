using System;

public class Entry
{
    string _date; // keep these all private for now
    string _prompt;
    string _response;

    // a constructor for the entry, inputting response and date and prompt into the class
    public Entry(string question, string inputText)
    {   
        _prompt = question;
        _response = inputText;
        _date = System.DateTime.Now.ToShortDateString(); // input date as a string
    }

    // a constructor for entry, taking in a date value, also
    public Entry(string question, string inputText, string time)
    {   
        _prompt = question;
        _response = inputText; // map inputs to the class variables
        _date = time;
    }

    // displays the entry, nicely formatted
    public void Display()
    {
        Console.WriteLine($"Date: {_date} -- Prompt: {_prompt}");
        Console.WriteLine(_response);
    }

    // gives a savefile-friendly version of this entry
    public string Save()
    {
        return $"{_date}~|~{_prompt}~|~{_response}"; 
    }
}