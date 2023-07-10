using System;

namespace OrbitalCollisions
{
    class Simulation
    {
        
        public Simulation() 
        {
            
        }

        private void PopulateUniverse()
        {
            string satPath = Path.Combine(Environment.CurrentDirectory, "Assets", "Satellite.png");
            BitmapImage satBitmap = new BitmapImage(new Uri(satPath)); // get a bitmap for this image (URI as input)

        }

        public void Begin()
        {

        }

        public void Stop()
        {

        }
    }
}
