using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalCollisions
{
    class Trajectory
    {
        private List<Vector> _path;
        public Trajectory()
        {
            _path = new List<Vector>();
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
