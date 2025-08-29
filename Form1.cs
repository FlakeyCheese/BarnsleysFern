namespace BarnsleysFern
{
    public partial class Form1 : Form
    {
        int screenX;
        int screenY;
        Color colour = Color.Green;
        public Form1()
        {
            InitializeComponent();
            this.DoubleBuffered = true; // Enable double buffering to reduce flickering
            this.Width = 800; // Set the width of the form
            this.Height = 1000; // Set the height of the form

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.Clear(Color.Black); // Clear the background to black  
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.AntiAlias; // Enable anti-aliasing for smoother lines
                                                                                // Draw the fern in the Paint event to ensure it is redrawn correctly

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int iterations = Convert.ToInt32(textBox1.Text);
            Graphics surface = CreateGraphics();
            Brush brush = new SolidBrush(colour);
            Random rand = new Random();
            double x = 0.0;
            double y = 0.0;
            for (int i = 0; i < iterations; i++)
            {
                double r = rand.NextDouble();
                if (r < 0.01)
                {
                    // Stem
                    x = 0.0;
                    y = 0.16 * y;
                }
                else if (r < 0.86)
                {
                    // Leaf
                    double x1 = 0.85 * x + 0.04 * y;
                    double y1 = -0.04 * x + 0.85 * y + 1.6;
                    x = x1;
                    y = y1;
                }
                else if (r < 0.93)
                {
                    // Left branch
                    double x1 = 0.2 * x - 0.26 * y;
                    double y1 = 0.23 * x + 0.22 * y + 1.6;
                    x = x1;
                    y = y1;
                }
                else
                {
                    // Right branch
                    double x1 = -0.15 * x + 0.28 * y;
                    double y1 = 0.26 * x + 0.24 * y + 0.44;
                    x = x1;
                    y = y1;
                }
                // Draw the point
                screenX = (int)(x * this.Width / 8 + this.Width / 2);
                screenY = (int)(-y * this.Height / 12 + this.Height * 0.9);
                surface.FillRectangle(brush, screenX, screenY, 2, 2);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            colorDialog1 = new ColorDialog();
            colorDialog1.ShowDialog();
            colour = colorDialog1.Color;

        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Invalidate();
        }
    }
}
