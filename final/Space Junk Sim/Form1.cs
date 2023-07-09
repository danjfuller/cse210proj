using System.Windows.Forms;

namespace Space_Junk_Sim
{
    public partial class Form1 : Form
    {
        private List<PictureBox> pictureBoxes = new List<PictureBox>();
        public Form1()
        {
            InitializeComponent();
            pictureBoxes = new List<PictureBox>();
            Image sat1 = global::Space_Junk_Sim.Properties.Resources.satellite;
            PictureBox satBox = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)(satBox)).BeginInit();
            satBox.Image = sat1;
            satBox.Location = new System.Drawing.Point(25, 300);
            satBox.Name = "Sat1";
            satBox.Size = new System.Drawing.Size(sat1.Width, sat1.Height);
            satBox.TabIndex = 0;
            satBox.TabStop = false;
            ((System.ComponentModel.ISupportInitialize)(satBox)).EndInit();
            pictureBoxes.Add(satBox);
        }

        private void Start(object sender, EventArgs e)
        {
            timer.Enabled = !timer.Enabled; // start and stop the program
        }

        private void Update(object sender, EventArgs e)
        {
            
        }
    }
}