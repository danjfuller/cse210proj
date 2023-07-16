using Gtk;
using Cairo;
using OrbitalCollisions;

// this class handles the view in the window for you. Simulation gives position data to it
// This class also integrates collision checks, then changes visuals accordingly
class View : DrawingArea
{
    private static float _metersPerPixel = 100000; // meters per pixel
    private Simulation _sim;
    
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
            // set the color of it
            c.SetSourceColor(_objects[i].Color());

            // Collision zone check
            for (int p = 0; p < plottedObjects.Count; p++) // simple collision checker
            {
                // check against all the previously plotted objects
                // if the distance between this object and a previously plotted object is within a screen pixel radius
                if ((_objects[i].GetPosition() - plottedObjects[p].GetPosition()).Magnitude() <
                    (_objects[i].GetCollisionRadius() + plottedObjects[p].GetCollisionRadius() + _metersPerPixel))
                {
                    c.SetSourceColor(_objects[i].CloseEncounter()); // set its color to a warning color
                    // now one object of the two will denote that it is too close to the other
                    //Console.WriteLine($"{objects[i].Name()} passed within 1 pixel of {plottedObjects[p].Name()} at this scale");
                }
            }
            plottedObjects.Add(_objects[i]);

            // plot the object
            Vector pos = _objects[i].GetPosition();
            pos = pos * (1.0f / _metersPerPixel); // scale the position to be in terms of pixel space
            // set radius
            float radius = _objects[i].GetCollisionRadius() / _metersPerPixel;
            if (radius < 5)
            {
                radius = 5; // radius can't be smaller than 5 pixels
            }
            // draw it
            c.Arc(pos.X() + MyWindow.Width() / 2.0, pos.Y() + MyWindow.Height() / 2.0f, radius , 0, Math.PI * 2); // draw a circle to represent them,origin is in center of window
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
