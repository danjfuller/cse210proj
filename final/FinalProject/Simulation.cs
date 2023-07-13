using System;

namespace OrbitalCollisions
{
    class Simulation
    {
        private List<Object> _objects;
        private float _timeStep = 6.0f; // simulated seconds per frame
        private float _mEarth = 5.97f * MathF.Pow(10, 27);
        private float _diamEarth = 12756000;
        private float _SpaceUnitsPerPixel = 100000; // 100 Kilometers per pixel

        public Simulation(int numSats) 
        {

            _objects = new List<Object>();
            for (int i = 0; i < numSats; i++)
            {
                Vector pos = new Vector(MathF.Cos(i * 45 * MathF.PI / 180.0f), MathF.Sin(i * 45 * MathF.PI / 180.0f)); // position at 45 degree increments around circle
                pos = pos.Normalized();
                pos.Scale(_diamEarth + 1000000); // put the satellites 1000 km above the earth surface (10 pixels at the start)

                Vector vel = new Vector(-1 * pos.Y(), pos.X()); // set their motion to be tangential to the center of the circle
                vel = vel.Normalized();
                Satellite sat = new Satellite(  2, // mass (2kg satellite)
                                                pos, // position
                                                vel); // velocity
                sat.SetVelocity(sat.OrbitalSpeed(_mEarth)); //make the satellite be at orbital speed around the earth
                //sat.setOrbitalSpeed(_mEarth);
                _objects.Add(sat); // velocity
                
            }
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
                obj.Move(_timeStep, _mEarth); // give time step and mass of the earth
            }
        }
    }
}
