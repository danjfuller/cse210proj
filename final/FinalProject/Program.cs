using Gtk;
using System;

public class GtkHelloWorld
{

    public static void Main()
    {
        Application.Init();

        //Create the Window
        Window myWin = new Window("Orbital Collision Simulator");
        myWin.Resize(1360, 780);

        // allow use to close the window and program
        myWin.DeleteEvent += delete_event;

        //Create a label and put some text in it.
        Label myLabel = new Label();
        myLabel.Text = "Hello World!!!!";

        //Add the label to the form
        myWin.Add(myLabel);

        //Show Everything
        myWin.ShowAll();

        Application.Run();
    }

    // runs when the user deletes the window using the "close
    // window" widget in the window frame.
    static void delete_event(object obj, DeleteEventArgs args)
    {
        Application.Quit();
    }

}