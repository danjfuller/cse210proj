using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

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
