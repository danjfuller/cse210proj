using System;
using Gtk;

// This is a test for the GTK library
class Program
{
    static void Main(string[] args)
    {
        Application.Init();

        //Create the Window
        Window myWin = new Window("Orbital Collision Simulator");
        myWin.Resize(780, 780);

        // allow use to close the window and program

        //Create a label and put some text in it.
        Label myLabel = new Label();
        myLabel.Text = "Hello World!!!!";

        //Add the label to the form
        myWin.Add(myLabel);

        //Show Everything
        myWin.ShowAll();

        Application.Run();
    }
}