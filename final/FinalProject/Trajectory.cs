using System;

namespace OrbitalCollisions
{
    // logs and tracks position data for plotting sake
    class Trajectory
    {
        private List<Vector> _path;
        private int waitTime = 20; // only log every few data points
        private int logged;
        public Trajectory()
        {
            _path = new List<Vector>(301);
            logged = new Random().Next(0,waitTime); // have each trajectory start logging data at a different time, to keep framerate smooth
        }

        // add a new vector to our trajectory, optimizing trajectory for storage
        public void Add(Vector v)
        {
            // if this is the time to log it,
            if(logged == 0) 
            { 
                _path.Add(v);
                if (_path.Count > 300)
                {
                    _path.RemoveAt(0); // remove the oldest
                }
                logged = waitTime; // restart counter
            }
            else
            {
                logged--; // count down to zero, then we'll log it
            }
            
        }

        // so other classes can plot our movement
        public List<Vector> GetPath()
        {
            return _path;
        }
    }
}
