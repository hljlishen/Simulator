using Mapper;
using System;
using System.Windows.Forms;

namespace PPI
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        PPIDisplay p;
        private void Form1_Load(object sender, EventArgs e)
        {
            IScreenToCoordinateMapper mapper = new ScreenToCoordinateMapper();
            mapper = new SquaredScreenRectDecorator(mapper);
            p = new PPIDisplay(pictureBox1, mapper);
        }

        private void range_btn_Click(object sender, EventArgs e)
        {
            p.Range = int.Parse(range_tb.Text);
        }

        private void markerCount_btn_Click(object sender, EventArgs e)
        {
            try
            {
                p.DistanceMarkerCount = uint.Parse(markerCount_tb.Text);
            }
            catch (Exception err)
            {
                Console.WriteLine(err.Message.ToString());
            }
        }
    }
}
