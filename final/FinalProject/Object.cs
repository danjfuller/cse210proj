using Gtk;
using System;
using System.Security.Cryptography.X509Certificates;
using System.Transactions;

namespace OrbitalCollisions
{
    class Object
    {
        private float _mass;
        private float _collisionRadius;
        private Vector _position;
        private Vector _velocity;
        private Trajectory _trajectory;
        private float _gravitationalConstant = 6.67430f * MathF.Pow(10, -11);
        private string _name;

        public Object(float mass, Vector position) 
        {
            _mass = mass;
            _position = position;
            _velocity = new Vector(0, 0); // default velocity of 0
            _trajectory = new Trajectory();
            _collisionRadius = 5; // meters as default collision radius for this object
            _trajectory.Add(position);
            _name = "Object"; // default name for object
        }

        public void SetName(string name)
        {
            _name = name;
        }

        // gives the name of this object
        public string Name()
        {
            return _name;
        }

        // this is so another class can plot the path made so far
        public List<Vector> GetPath()
        {
            return _trajectory.GetPath();
        }

        public void SetVelocity(float magnitude, Vector direction)
        {
            _velocity = direction.Normalized();
            _velocity.Scale(magnitude);
        }

        public void SetVelocity(Vector velocity)
        {
            _velocity = velocity;
        }

        protected void SetCollisionRadius(float radius)
        {
            _collisionRadius = radius;
        }

        public float GetCollisionRadius()
        {
            return _collisionRadius;
        }

        public Vector GetPosition()
        {
            return _position;
        }

        public void Move(float timeStep, float planetMass)
        {

            float F_Gravity = _gravitationalConstant * planetMass * _mass / MathF.Pow(_position.Magnitude(), 2); // magnitude of gravitational force
            Vector G_Dir = new Vector(-_position.X(), - _position.Y()); // assume the planet is at the center of the coordinate system
            Vector Acc = G_Dir.Normalized() * (F_Gravity / _mass); // acceleration vector
            
            // Euler's Method: (ask your math teacher)
            _velocity = _velocity + (Acc * timeStep);

            _position = _position + (_velocity * timeStep); //+ (Acc * (0.5f * timeStep * timeStep)); // move along your velocity path
            _trajectory.Add(_position);
        }

        // sets the object to be at a speed that will keep it in a stable circular orbit
        public Vector OrbitalSpeed(float centralMass)
        {
            float v = MathF.Sqrt(_gravitationalConstant * centralMass / _position.Magnitude()); // magnitude of their velocity
            Vector vel = new Vector(-_position.Y(), _position.X());
            vel = vel.Normalized() * v;
            Console.WriteLine($"{_name} orbital Speed: {v} m/s");
            return vel;
        }
    }
}
