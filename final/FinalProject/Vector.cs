using System;

namespace OrbitalCollisions
{
    // Handles the 2D vectors of this program
    class Vector
    {
        private float _x;
        private float _y;
        private static readonly Vector _up = new Vector(0, 1);
        private static readonly Vector _zero = new Vector(0, 0);

        public Vector(float x, float y)
        {
            _x = x;
            _y = y;
        }

        public Vector Scale(float amount)
        {
            _x = amount * _x;
            _y = amount * _y;
            return this;
        }

        public Vector Normalized()
        {
            float scalar = 1.0f / Magnitude();
            return this * scalar;
        }
        
        public float Magnitude()
        {
            return MathF.Sqrt(_x * _x + _y * _y);
        }
        
        public float X()
        {
            return _x;
        }

        public float Y()
        {
            return _y;
        }


        // static methods for math use
        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X() + b.X(), a.Y() + b.Y());
        }

        public static Vector operator -(Vector a, Vector b)
        {
            return new Vector(a.X() -  b.X(), a.Y() - b.Y());
        }

        public static Vector operator *(Vector a, float scalar)
        {
            return new Vector(a.X() * scalar, a.Y() * scalar);
        }
    }
}
