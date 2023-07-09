using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalCollisions
{
    class Satellite : Object
    {
        public Satellite(float mass, Vector position, Vector velocity) : base(mass, position)
        {
            SetVelocity(velocity);
        }
    }
}
