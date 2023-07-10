using System;

namespace OrbitalCollisions
{
    class Object
    {
        private float _mass;
        private float _collisionRadius;
        private Vector _position;
        private Vector _veclocity;

        public Object(float mass, Vector position) 
        {
            _mass = mass;
            _position = position;
            _veclocity = new Vector(0, 0);
        }

        public void SetVelocity(float magnitude, Vector direction)
        {
            _veclocity = direction.Normalized();
            _veclocity = _veclocity.Scale(magnitude);
        }

        public void SetVelocity(Vector velocity)
        {
            _veclocity = velocity;
        }

        protected void SetCollisionRadius(float radius)
        {
            _collisionRadius = radius;
        }
    }
}
