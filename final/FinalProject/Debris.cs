using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalCollisions
{
    class Debris : Object
    {
        private float _elasticity;

        public Debris(float mass, Vector position, Vector velocity) : base(mass, position)
        {
            _elasticity = 0.5f; // half value
            SetCollisionRadius(0.5f); // small collision size
            SetVelocity(velocity.Magnitude(), velocity);
        }

        public float GetElasticity()
        {
            return _elasticity;
        }
    }
}
