using System;
using System.Security.Cryptography.X509Certificates;

namespace OrbitalCollisions
{
    class Simulation
    {
        private List<Object> _objects;
        private float _timeStep = 20.0f; // simulated seconds per frame
        private float _mEarth = 5.97219f * MathF.Pow(10, 24);
        private float _diamEarth = 6371000;
        private float _SpaceUnitsPerPixel = 100000; // meters per pixel

        public Simulation(int numSats) 
        {

            _objects = new List<Object>();
            for (int i = 0; i < numSats; i++)
            {
                Satellite sat = CreateSat(i);
                _objects.Add(sat); // velocity
                
            }

            // add the Moon as well
            Planet moon = new Planet(7.347f * MathF.Pow(10, 22), // mass
                                        1737.4f * 1000.0f, // radius
                                        new Vector(384400 * 1000, 0)); //position
            moon.SetVelocity(1022.0f, new Vector(0, -1));
            _objects.Add(moon); // data for the moon's orbit

        }

        // creates a satellite to use, with a randomized altitude and orbital speed.
        // designate what angle it should be at to start
        private Satellite CreateSat(float degree45Increment)
        {
            Random random = new Random();
            Vector pos = new Vector(MathF.Cos(degree45Increment * 45 * MathF.PI / 180.0f), MathF.Sin(degree45Increment * 45 * MathF.PI / 180.0f)); // position at 45 degree increments around circle
            pos = pos.Normalized();
            pos.Scale(_diamEarth + 100000 // put the satellites 100 km above the earth surface (10 pixels at the start)
                                    + random.Next(0, 200 * 100000)); // then add on somewhere between 0 to N times the sufrace distance

            Vector vel = new Vector(-1 * pos.Y(), pos.X()); // set their motion to be tangential to the center of the circle
            vel = vel.Normalized();
            Satellite sat = new Satellite(2, // mass (2kg satellite)
                                            pos, // position
                                            vel); // velocity
                                                  //make the satellite be at orbital speed around the earth plus a little extra to make it interesting
            sat.SetVelocity(sat.OrbitalSpeed(_mEarth).Magnitude() + (1000 * (MathF.Exp(random.Next(0, 1000) / 1000) - 1) ), sat.OrbitalSpeed(_mEarth));
            //sat.setOrbitalSpeed(_mEarth);
            return sat;
        }

        public float TimeStep()
        {
            return _timeStep;
        }

        public float MetersPerPixel()
        {
            return _SpaceUnitsPerPixel; // how much one pixel currently represents in meters
        }

        public float DiamCenterPlanet()
        {
            return _diamEarth;
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
