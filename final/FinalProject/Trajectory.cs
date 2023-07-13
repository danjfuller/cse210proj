using System;

namespace OrbitalCollisions
{
    class Trajectory
    {
        private List<Vector> _path;
        public Trajectory(Vector initialV)
        {
            _path = new List<Vector>();
        }

        private void SetUpTrajectory()
        {
            float dt = 0.1f;
            for(float t = 0; t < 10; t+= dt)
            {
                _path.Add(new Vector(MathF.Cos(t),MathF.Sin(t)));
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
