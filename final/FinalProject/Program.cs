using Cairo;
using Gdk;
using Gtk;
using OrbitalCollisions;
using Key = Gdk.Key;
using Timeout = GLib.Timeout;

// this class handles the window for you. Sim gives position data
class View : DrawingArea
{
    Simulation _sim;
    //ImageSurface sat = new ImageSurface("C:\\Users\\Dan F\\Documents\\cse210proj\\final\\FinalProject\\satellite.png");
    //ImageSurface sat2 = new ImageSurface("C:\\Users\\Dan F\\Documents\\cse210proj\\final\\FinalProject\\satellite.png");

    public View(Simulation sim)
    {
        _sim = sim;
    }

    protected override bool OnDrawn(Context c) // override the drawing method for the window
    {
        Cairo.Color satColor = new Cairo.Color(1, 0, 0);
        Cairo.Color planetColor = new Cairo.Color(0, 0, 1);

        // draw the planet
        c.SetSourceColor(planetColor); // blue color
        c.Arc(MyWindow.Width() / 2.0, MyWindow.Height() / 2.0, _sim.DiamCenterPlanet()/_sim.MetersPerPixel(), 0.0, Math.PI * 2.0); // planet at center
        c.Fill();

        // draw a circle to represent each Object
        List<OrbitalCollisions.Object> objects = _sim.GetObjects();
        for (int i = 0; i < objects.Count; i++)
        {
            Vector pos = objects[i].GetPosition();
            float radius = objects[i].GetCollisionRadius() / _sim.MetersPerPixel(); // get the radius for this object
            if(radius < 3.0f)
            {
                radius = 3; // create a minimum size
                c.SetSourceColor(satColor); // it's a satellite
            }
            else
            {
                c.SetSourceColor(planetColor); // its a planet, likely
            }
            pos = pos * (1.0f / _sim.MetersPerPixel()); // scale the position to be in terms of pixel space
            c.Arc(pos.X() + MyWindow.Width()/2.0, pos.Y() + MyWindow.Height()/2.0f, radius, 0, Math.PI * 2); // draw a circle to represent them,origin is in center of window
            c.Fill();

            // Draw trajectory now
            DrawTrajectory(objects[i], c);

        }

        return true;
    }

    // draws the past trajectory of an object
    private void DrawTrajectory(OrbitalCollisions.Object obj, Context c)
    {
        List<Vector> points = obj.GetTrajectory();
        if (points.Count > 2)
        {
            c.SetSourceRGB(0.5, 0.5, 0.5); // dark line
            c.LineWidth = 1; // small as possible line
            Vector pixel = ScreenCoordinate(points[points.Count - 1]);
            c.MoveTo(pixel.X(), pixel.Y());
            for (int p = points.Count - 2; p > 0; p--)
            {
                pixel = ScreenCoordinate(points[p]);
                c.LineTo(pixel.X(), pixel.Y());
            }
            c.Stroke(); // pick up the pen
        }
    }

    private Vector ScreenCoordinate(Vector simPoint)
    {
        return new Vector(simPoint.X()/_sim.MetersPerPixel() + MyWindow.Width()/2.0f, simPoint.Y()/_sim.MetersPerPixel() + MyWindow.Height()/2.0f);
    }
}

class MyWindow : Gtk.Window
{
    Simulation sim;
    //HashSet<Key> keys = new HashSet<Key>(); in case keyboard is used
    private static int _width = 1280;
    private static int _height = 800;

    public MyWindow() : base("Orbital Collision Simulator")
    {
        /* // This section is experimental
        Box zoomButtons = new Box(Orientation.Horizontal, 5);
        zoomButtons.Add(new Label("Zoom: "));
        zoomButtons.Add(new Button("In"));
        zoomButtons.Add(new Button("Out"));
        Add(zoomButtons);
        */

        Resize(_width, _height);

        sim = new Simulation(10); //new simulation with N sats
        Add(new View(sim));
        Timeout.Add(30, on_timeout); // 1 tick per every N milliseconds
        float timeScaling = (1000.0f / 30.0f) * sim.TimeStep();
        Console.WriteLine($"Simulation Scaling: {timeScaling}s per second");
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
        sim.tick();
        //tick(keys.Contains(Key.Left), keys.Contains(Key.Right));
        QueueDraw();
        return true;
    }

    /*
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

class Program
{
    static void Main()
    {
        Application.Init();
        MyWindow w = new MyWindow();
        w.ShowAll();
        Application.Run();
    }
}