using Cairo;
using Gdk;
using Gtk;
using OrbitalCollisions;
using Key = Gdk.Key;
using Timeout = GLib.Timeout;

// old example class
class Game
{
    public int player_x = 200, player_y = 600;
    int dy = 0;     // vertical velocity in pixels/tick

    public void tick(bool move_left, bool move_right)
    {
        if (move_left)
            player_x -= 5;
        else if (move_right)
            player_x += 5;

        player_y += dy;
        if (player_y >= 600)
        {  // hit the ground
            dy = 0;     // stop falling
            player_y = 600;
        }
        else
            dy += 2;    // accelerate downward
    }

    public void jump()
    {
        if (player_y == 600 && dy == 0)
            dy = -20;
    }
}

// this class handles the window for you. Sim gives position data
class View : DrawingArea
{
    Game game;
    Simulation _sim;
    //ImageSurface sat = new ImageSurface("C:\\Users\\Dan F\\Documents\\cse210proj\\final\\FinalProject\\satellite.png");
    //ImageSurface sat2 = new ImageSurface("C:\\Users\\Dan F\\Documents\\cse210proj\\final\\FinalProject\\satellite.png");

    public View(Game game, Simulation sim)
    {
        this.game = game;
        _sim = sim;
    }

    protected override bool OnDrawn(Context c) // override the drawing method for the window
    {
        Cairo.Color satColor = new Cairo.Color(1, 0, 0);

        // draws a line
        //c.SetSourceRGB(0, 0, 0);
        //c.MoveTo(0, 600);
        //c.LineTo(800, 600);
        //c.Stroke(); // pick up the pen

        // dino jump part
        //c.SetSourceSurface(sat, game.player_x, game.player_y - sat.Height);
        //c.Paint();

        // draw the planet
        c.SetSourceRGB(0, 0, 1); // blue color
        c.Arc(MyWindow.Width() / 2, MyWindow.Height() / 2, _sim.DiamCenterPlanet()/_sim.MetersPerPixel(), 0.0, Math.PI * 2); // planet at center
        c.Fill();

        // draw a circle to represent each satellite
        List<OrbitalCollisions.Object> objects = _sim.GetObjects();
        c.SetSourceColor(satColor);
        for (int i = 0; i < objects.Count; i++)
        {
            Vector pos = objects[i].GetPosition();
            pos = pos * (1.0f / _sim.MetersPerPixel()); // scale the position to be in terms of pixel space
            c.Arc(pos.X() + MyWindow.Width()/2.0, pos.Y() + MyWindow.Height()/2.0f, 5, 0, Math.PI * 2); // draw a circle to represent them,origin is in center of window
            c.Fill();
        }

        return true;
    }
}

class MyWindow : Gtk.Window
{
    Game game = new Game();
    Simulation sim;
    HashSet<Key> keys = new HashSet<Key>();
    private static int _width = 800;
    private static int _height = 800;

    public MyWindow() : base("Orbital Collision Simulator")
    {
        Resize(_width, _height);
        sim = new Simulation(5); //new simulation with 5 sats
        Add(new View(game, sim));
        Timeout.Add(30, on_timeout); // 1 tick per 30 milliseconds
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
        game.tick(keys.Contains(Key.Left), keys.Contains(Key.Right));
        QueueDraw();
        return true;
    }

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