using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrbitalCollisions
{
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
            return Scale(scalar);
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

        public static float Dot(Vector a, Vector b)
        {
            return 0.0f;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            return new Vector(a.X() + b.X(), a.Y() + b.Y());
        }

        public static Vector Cross(Vector left, Vector right)
        {
            return _up;
        }

        public static Vector Interpolate(Vector a, Vector b, float percentage)
        {
            return _up;
        }
    }
}
