using System;

namespace OrbitalCollisions
{
    class Trajectory
    {
        private List<Vector> _path;
        private int waitTime = 20; // only log every few data points
        private int logged;
        public Trajectory()
        {
            _path = new List<Vector>();
            logged = new Random().Next(0,waitTime); // have each trajectory start logging data at a different time, to keep framerate smooth
        }

        // add a new vector to our trajectory, optimizing trajectory for storage
        public void Add(Vector v)
        {
            // if this is at 0
            if(logged == 0) 
            { 
                _path.Add(v);
                if (_path.Count > 500)
                {
                    _path.RemoveAt(0); // remove the oldest
                }
                logged = waitTime; // restart counter
            }
            else
            {
                logged--; // count down to zero
            }
            
        }

        public List<Vector> GetTrajectory()
        {
            return _path;
        }

        private float WhenCollide(Trajectory otherPath)
        {
            return 0.0f;
        }

        public void Plot()
        {
            return;
        }

        public List<Vector> NextSpots()
        {
            return _path.GetRange(0, 5); // next 5 points for now
        }

        public bool WillCollide()
        {
            return false;
        }
    }
}
