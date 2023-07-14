using System;

namespace OrbitalCollisions
{
    class Planet : Object
    {
        public Planet(float mass, float radius, Vector position) : base(mass, position)
        {
            SetCollisionRadius(radius); // this also lets the window know how big to make the circle for it
        }
    }
}
