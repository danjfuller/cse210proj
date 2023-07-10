using System;

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
