using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ErrorProviderTest
{
    class E
    {
        public ErrorProvider e = new ErrorProvider();

        public E()
        {
            e.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }

        public void SetError(Control c, string msg)
        {
            e.SetError(c, msg);
        }

        public void Cue()
        {
            Timer t = new Timer();
            t.Interval = 3000;
            t.Tick += T_Tick;
            t.Start();

            e.BlinkStyle = ErrorBlinkStyle.AlwaysBlink;
            e.BlinkRate = 500;
        }

        private void T_Tick(object sender, EventArgs e)
        {
            this.e.BlinkStyle = ErrorBlinkStyle.NeverBlink;
        }
    }
}
