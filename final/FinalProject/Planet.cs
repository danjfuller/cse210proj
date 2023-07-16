using Cairo;
using System;

namespace OrbitalCollisions
{
    class Planet : Object
    {
        // we assume that the planet has no need to move
        public Planet(float mass, float radius, Vector position, string name) : base(mass, position, name)
        {
            SetCollisionRadius(radius); // this also lets the window know how big to make the circle for it
            _color = new Cairo.Color(0, 0, 1);
        }

        public override Color CloseEncounter()
        {
            return _color; // large objects, such as planets, do not need to be colored when others get too close
        }
    }
}
