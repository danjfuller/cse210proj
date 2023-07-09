using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace OrbitalCollisions
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Main();
        }

        public static ImageSource satSource = LoadSat();

        public void Main()
        {
            Image image = new Image();
            image.Source = LoadSat();
            image.Name = "sat1";
            image.Width = satSource.Width;
            image.Height = satSource.Height;
            Image image2 = new Image();
            image2.Source = LoadSat();
            image2.Name = "sat2";
            image2.Width = satSource.Width;
            image2.Height = satSource.Height;

            image2.Stretch = Stretch.Fill;
            image.Stretch = Stretch.Fill;

            AllSats.Items.Add(image);
            AllSats.Items.Add(image2);
            image.TranslatePoint(new Point(Width/3, 2*Height/3),image);
            
            Canvas.SetTop(image2, 100);
            Canvas.SetLeft(image2, 100);
        }

        public void UpdateCounters()
        {
            // code to update stats of simulation
        }

        public static ImageSource LoadSat()
        {
            return new BitmapImage(new Uri("C:\\Users\\Dan F\\Documents\\cse210proj\\final\\OrbitalCollisions\\Assets\\Satellite.png")); // get a bitmap for this image (URI as input)
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Simulation simulation = new Simulation();
            simulation.Begin();


        }
    }
}
