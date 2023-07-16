using System;

namespace OrbitalCollisions
{
    class Satellite : Object
    {
        // satellites start out by having mass of 2kg
        public Satellite(Vector position, Vector velocity) : base(2, position)
        {
            // set the specified velocity. Satellites should start out as moving
            SetVelocity(velocity);
        }
    }
}
