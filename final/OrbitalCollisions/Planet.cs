using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalCollisions
{
    class Planet : Object
    {
        public Planet(float mass, float radius, Vector position) : base(mass, position)
        {
            SetCollisionRadius(radius);
        }
    }
}
