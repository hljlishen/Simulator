using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrorProviderTest
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }
        ErrorProvider e1;
        E e2;
        private void Form1_Load(object sender, EventArgs e1)
        {
            //e1 = new ErrorProvider();
            //e1.BlinkStyle = ErrorBlinkStyle.NeverBlink;
            //e1.SetError(textBox1, "1111");
            //e1.SetError(textBox2, "1111");
            //var str = e1.GetError(textBox1);
            ////e1.SetError(textBox1, "");
            //str = e1.GetError(textBox1);

            //e1.BlinkStyle = ErrorBlinkStyle.BlinkIfDifferentError;
            //e1.BlinkRate = 1000;

            e2 = new E();
            e2.SetError(textBox1, "1111111");

            pictureBox1.Paint += PictureBox1_Paint;

        }

        private void PictureBox1_Paint(object sender, PaintEventArgs e)
        {
            
        }

        private void Button1_Click(object sender, EventArgs e)
        {
            //e1.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            //e1.BlinkRate = 500;
            e2.Cue();
        }

        private void PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
