using System;
using System.Security.Cryptography.X509Certificates;

// This class runs the simulation
namespace OrbitalCollisions
{
    class Simulation
    {
        private List<Object> _objects;
        private float _timeStep = 20.0f; // simulated seconds per frame
        private float _mEarth = 5.97219f * MathF.Pow(10, 24);
        private float _radiusEarth = 6371140; // meters
        Random _random;

        public Simulation(int numSats) 
        {
            _random = new Random();
            _objects = new List<Object>();

            // add Earth at the center
            Planet earth = new Planet(_mEarth, _radiusEarth, new Vector(0.0f, 0.0f), "Earth"); // careful, as gravitational force at center is very high
            earth.SetAsStatic(); // the earth doesn't move in this simulation
            _objects.Add(earth);

            // create satellites
            for (int i = 0; i < numSats; i++)
            {
                Satellite sat = CreateSat(i, i); // make increment same as number for simplicity
                _objects.Add(sat);
            }

            // add the Moon as well
            Planet moon = new Planet(7.347f * MathF.Pow(10, 22), // mass
                                        1737.4f * 1000.0f, // radius
                                        new Vector(384467 * 1000, 0), //position
                                        "Moon"); // name
            moon.SetVelocity(1022.0f, new Vector(0, 1));    // set moon to orbit in same direction as satellites are likely
                                                            // launched in same orbit direction as the earth and moon rotation
            _objects.Add(moon);

        }

        // creates a satellite to use, with a randomized altitude and orbital speed.
        // designate what angle it should be at to start
        private Satellite CreateSat(float degree45Increment, int num)
        {
            Vector pos = new Vector(MathF.Cos(degree45Increment * 45 * MathF.PI / 180.0f), MathF.Sin(degree45Increment * 45 * MathF.PI / 180.0f)); // position at 45 degree increments around circle
            pos = pos.Normalized();
            pos.Scale(_radiusEarth + 400000 + // put the satellites 400 km above the earth surface
                                    ( 500 * 100000 * RandomizedAmount(9))); // then add on somewhere between 0 to 500 times the surface distance

            Vector vel = new Vector(-1 * pos.Y(), pos.X()); // set their motion to be tangential to the center of the circle
            vel = vel.Normalized();
            Satellite sat = new Satellite(  pos, // position
                                            vel, // velocity
                                            num); // number of satellite
                                                  //make the satellite be at orbital speed around the earth plus a little extra to make it interesting
            sat.SetVelocity(sat.OrbitalSpeed(_mEarth) * (1 + 0.2f * RandomizedAmount(6)) );
            //sat.setOrbitalSpeed(_mEarth);
            return sat;
        }

        // returns a value near 1.0 with very few outliers, but obvious ones
        // higher normality number returns less outliers
        private float RandomizedAmount(int normality)
        {
            return MathF.Pow(_random.Next(1, 1000) / 1000.0f, normality);
        }

        public float TimeStep()
        {
            return _timeStep;
        }

        public float RadiusCenterPlanet()
        {
            return _radiusEarth;
        }

        public List<Object> GetObjects()
        {
            return _objects;
        }

        public void tick()
        {
            foreach (OrbitalCollisions.Object obj in _objects)
            {
                obj.Move(_timeStep / 2.0f, _mEarth); // do this calculation twice for greater accuracy
                obj.Move(_timeStep / 2.0f, _mEarth); // give time step and mass of the earth
            }
        }
    }
}
