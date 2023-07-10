using System;

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
