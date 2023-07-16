using Gtk;
using Cairo;
using OrbitalCollisions;

// this class handles the view in the window for you. Simulation gives position data to it
// This class also integrates collision checks, then changes visuals accordingly
class View : DrawingArea
{
    private static float _metersPerPixel = 100000; // meters per pixel
    Simulation _sim;
    private Cairo.Color _satColor = new Cairo.Color(1, 0, 0);
    private Cairo.Color _closeEncounter = new Cairo.Color(0, 1, 0);
    private Cairo.Color _planetColor = new Cairo.Color(0, 0, 1);
    private List<OrbitalCollisions.Object> _objects;
    private bool _firstCall;

    public View(Simulation sim)
    {
        _sim = sim;
        _firstCall = true; // this is a flag to mark the first frame draw
    }

    public static void SetMetersPerPixel(float metersPerPixel)
    {
        _metersPerPixel = metersPerPixel;
    }

    public static float MetersPerPixel()
    {
        return _metersPerPixel;
    }

    protected override bool OnDrawn(Context c) // override the drawing method for the window
    {
        if(_firstCall)
        {
            _objects = _sim.GetObjects(); // get our objects list set up on the first draw
            _firstCall = false;
        }

        // draw the center planet, and treat it as though it is stationary
        c.SetSourceColor(_planetColor); // blue color
        c.Arc(MyWindow.Width() / 2.0, MyWindow.Height() / 2.0, _sim.RadiusCenterPlanet() / _metersPerPixel, 0.0, Math.PI * 2.0); // planet at center
        c.Fill();

        // draw each satellite trajectory first
        for (int t = 0; t < _objects.Count; t++)
        {
            // Draw its trajectory
            DrawTrajectory(_objects[t], c);
        }

        // draw a circle to represent each Object
        List<OrbitalCollisions.Object> plottedObjects = new List<OrbitalCollisions.Object>(); // list of previously plotted objects
        for (int i = 0; i < _objects.Count; i++)
        {

            // set the color if it
            float radius = _objects[i].GetCollisionRadius() / _metersPerPixel; // get the radius for this object
            if (radius < 3.0f)
            {
                radius = 3; // create a minimum size
                c.SetSourceColor(_satColor); // it's a satellite
            }
            else
            {
                c.SetSourceColor(_planetColor); // its a planet, likely
            }

            // Collision zone check
            for (int p = 0; p < plottedObjects.Count; p++) // simple collision checker
            {
                // check against all the previously plotted objects
                // if the distance between this object and a previously plotted object is within a screen pixel radius
                if ((_objects[i].GetPosition() - plottedObjects[p].GetPosition()).Magnitude() <
                    (_objects[i].GetCollisionRadius() + plottedObjects[p].GetCollisionRadius() + _metersPerPixel))
                {
                    c.SetSourceColor(_closeEncounter); // set its color to a warning color
                    //Console.WriteLine($"{objects[i].Name()} passed within 1 pixel of {plottedObjects[p].Name()} at this scale");
                }
            }
            plottedObjects.Add(_objects[i]);

            // plot the object
            Vector pos = _objects[i].GetPosition();
            pos = pos * (1.0f / _metersPerPixel); // scale the position to be in terms of pixel space
            c.Arc(pos.X() + MyWindow.Width() / 2.0, pos.Y() + MyWindow.Height() / 2.0f, radius, 0, Math.PI * 2); // draw a circle to represent them,origin is in center of window
            c.Fill();
        }

        return true;
    }

    // draws the past trajectory of an object
    private void DrawTrajectory(OrbitalCollisions.Object obj, Context c)
    {
        List<Vector> points = obj.GetPath();
        if (points.Count > 2)
        {
            c.SetSourceRGB(0.5, 0.5, 0.5); // dark line
            c.LineWidth = 1; // small as possible line

            Vector pixel = ScreenCoordinate(obj.GetPosition());
            c.MoveTo(pixel.X(), pixel.Y()); // start the line where object is right now
            
            // now work backwards in time to plot our past points
            for (int p = points.Count - 1; p > 0; p--)
            {
                pixel = ScreenCoordinate(points[p]);
                c.LineTo(pixel.X(), pixel.Y());
            }
            c.Stroke(); // pick up the pen
        }
    }

    private Vector ScreenCoordinate(Vector simPoint)
    {
        return new Vector((simPoint.X() / _metersPerPixel) + MyWindow.Width() / 2.0f, (simPoint.Y() / _metersPerPixel) + MyWindow.Height() / 2.0f);
    }
}
