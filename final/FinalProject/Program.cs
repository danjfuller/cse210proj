using Cairo;
using Gtk;
using OrbitalCollisions;
using System;

// By Daniel Fuller, July 2023
// This program creates and shows a simulation of satellites in orbit centered around the earth.
// It includes the moon, as well- Set the km per pixel to 800 to see it.
class Program
{
    static void Main()
    {
        Console.WriteLine("Orbital Collision Simulator v1.1\n");
        Console.WriteLine("Created By Daniel Fuller, July 2023\n");
        Console.WriteLine("Brief Intro: ");
        Console.WriteLine("-Satellites are marked in RED");
        Console.WriteLine("-Planets and other circulate bodies are marked in BLUE");
        Console.WriteLine("-Satellites that pass very close to another (within a");
        Console.WriteLine(" pixel distance) are marked as GREEN while this happens");
        Console.WriteLine("-NOTE: Both this Terminal and the GUI program show information.\n");
        int numSats = 1;
        bool valid = false;
        do
        {
            Console.Write("How many Satellites? (default is 10, max is 99) : ");
            string ans = Console.ReadLine();
            if(ans == "")
            {
                numSats = 10; // do default value
                valid = true;
            }
            else if (int.TryParse(ans, out int num) && num < 100 && num > 0)
            {
                numSats = num; // get a valid number from the User
                valid = true;
            }
            else
            {
                Console.WriteLine("Invalid answer. Please give an integer number less than 100, atleast 1");
            }
        } while (!valid); // keep going until we get a valid number

        Application.Init();
        MyWindow w = new MyWindow(numSats); // new window with num sats set 
        w.ShowAll();
        Application.Run(); // this is what draws the screen
    }
}