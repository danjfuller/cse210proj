using System;

namespace OrbitalCollisions
{
    class Satellite : Object
    {
        // satellites start out by having mass of 2kg
        public Satellite(Vector position, Vector velocity, int num) : base(2, position, $"Sat {num}")
        {
            // set the specified velocity. Satellites should start out as moving
            SetVelocity(velocity);
            _color = new Cairo.Color(1, 0, 0); // satellites are red
        }


    }
}
