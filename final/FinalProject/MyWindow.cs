using Cairo;
using Gdk;
using Gtk;
using OrbitalCollisions;
using Key = Gdk.Key;
using Timeout = GLib.Timeout;

// This class handles the window properties
class MyWindow : Gtk.Window
{
    Simulation sim;
    //HashSet<Key> keys = new HashSet<Key>(); in case keyboard is used later
    private static int _width = 1280;
    private static int _height = 800;

    public MyWindow(int numSats) : base("Orbital Collision Simulator")
    {
        Resize(_width, _height);
        sim = new Simulation(numSats); //new simulation with N sats

        View view = new View(sim);
        Add(new View(sim));
        Timeout.Add(30, on_timeout); // 1 tick per every N milliseconds

        float timeScaling = (1000.0f / 30) * sim.TimeStep();
        Console.WriteLine($"\nSimulation Scaling: {timeScaling}s simulated per second");

        float defaultKmPerPixel = 100.0f;
        Console.WriteLine("Earth's radius ~ 6378 km. Moon's distance ~ 384,467 km");
        Console.Write($"Kilometers per pixel? (default is {defaultKmPerPixel}) : ");
        string ans = Console.ReadLine();
        if (float.TryParse(ans, out float scale) && scale > 0.0f)
        {
            View.SetMetersPerPixel(scale * 1000.0f); // set the scale
        }
        else
        {
            View.SetMetersPerPixel(defaultKmPerPixel * 1000.0f); // else just do default scaling
        }
    }

    public static int Width()
    {
        return _width;
    }

    public static int Height()
    {
        return _height;
    }

    // function to run the ticks
    bool on_timeout()
    {
        sim.tick(); // run the sim one frame
        //tick(keys.Contains(Key.Left), keys.Contains(Key.Right));
        QueueDraw(); // redraw the screen
        return true;
    }

    /*
    // for keypress options
    protected override bool OnKeyPressEvent(EventKey e)
    {
        if (e.Key == Key.space)
            game.jump();
        else
            keys.Add(e.Key);

        return true;
    }

    protected override bool OnKeyReleaseEvent(EventKey e)
    {
        keys.Remove(e.Key);
        return true;
    }
    */

    protected override bool OnDeleteEvent(Event ev)
    {
        Application.Quit();
        return true;
    }
}
