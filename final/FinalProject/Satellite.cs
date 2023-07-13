using System;

namespace OrbitalCollisions
{
    class Satellite : Object
    {
        // satellites start out by moving
        public Satellite(float mass, Vector position, Vector velocity) : base(mass, position)
        {
            SetVelocity(velocity);
        }
    }
}
