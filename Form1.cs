using Simulation.Entities;
using System.Drawing;
using System.Drawing.Design;
using System.Drawing.Text;
namespace Simulation
{
    public partial class Form1 : Form
    {
        private System.Windows.Forms.Timer _timer;
        private List<Entity> herbivores;
        private List<Entity> carnivores;
        private int ScreenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width;
        private int ScreenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;

        public Form1()
        {
            _timer = new System.Windows.Forms.Timer();

            herbivores = new List<Entity>()
            {
                new HerbivoreEntity{ },
                new HerbivoreEntity{ },
                new HerbivoreEntity{ }
            };

            carnivores = new List<Entity>()
            {
                new CarnivoreEntity{ },
                new CarnivoreEntity{ },
                new CarnivoreEntity{ }
            };

            this.WindowState = FormWindowState.Maximized;
            this.DoubleBuffered = true;
            this.FormBorderStyle = FormBorderStyle.None;

            InitializeComponent();
            CenterToScreen();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            herbivores = InitialCoordinates(herbivores);
            carnivores = InitialCoordinates(carnivores);

            _timer.Tick += timer1_Tick;
        }

        private void Form1_Paint(object sender, PaintEventArgs pe)
        {
            Graphics g = pe.Graphics;

            foreach (var entity in herbivores)
            {
                g.FillRectangle(entity.Color,
                    new Rectangle(entity.CurrentPositionX, entity.CurrentPositionY, entity.Width, entity.Height));
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Invalidate();
        }

        private List<Entity> InitialCoordinates(List<Entity> entities)
        {
            foreach (var entity in entities)
            {
                entity.CurrentPositionX = new Random().Next(0, ScreenWidth);
                entity.CurrentPositionY = new Random().Next(0, ScreenHeight);
            }

            return entities;
        }

    }
}
