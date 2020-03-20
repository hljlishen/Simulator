using System;
using System.Windows.Forms;
using Mapper;
using PPI;

namespace SimView
{
    public partial class ControlPanel : Form
    {
        private PPIDisplay display;
        private IScreenToCoordinateMapper mapper;
        private ITacanController controller;
        private InputValidation validation;
        public ControlPanel(ITacanController controller)
        {
            InitializeComponent();

            //controller.Write(0x54000, 0xAA);
            mapper = new SquaredScreenRectDecorator(new ScreenToCoordinateMapper());

            display = new PPIDisplay(ppi_pb, mapper);
            display.DmeStateChanged += Display_DmeStateChanged;
            this.controller = controller;
            UpdateForm(controller.Model);

            validation = new InputValidation();
            validation.AddValidation(channel_tb, new IntStrInRange(ValueInterval.CloseClose(126, 1)));
            validation.AddValidation(randomPulse_tb, new IntStrInRange(ValueInterval.CloseClose(10000, 0)));
            validation.AddValidation(modulation15_tb, new DoubleStrInRange(ValueInterval.CloseClose(100, 0)));
            validation.AddValidation(modulation135_tb, new DoubleStrInRange(ValueInterval.CloseClose(100, 0)));
        }
        private void Display_DmeStateChanged(double arg1, double arg2)
        {
            az_tb.Text = arg1.ToString("0.00");
            dis_tb.Text = arg2.ToString("0.00");
        }
        private void UpdateForm(TacanModel model)
        {
            _ = model.Distance_ini.ToString("0.00");
            dis_tb.Text = model.Distance_ini.ToString("0.00");
            az_tb.Text = model.Azimuth_ini.ToString("0.00");
            channel_tb.Text = model.Channel_ini.ToString();
            responsePower_tkb.Value = (int)model.ResponsePower_ini;
            randomPulse_tb.Text = model.RandomPulse_ini.ToString();
            modulation15_tb.Text = model.Modulation15_ini.ToString();
            modulation135_tb.Text = model.Modulation135_ini.ToString();
            responseRate_tb.Text = model.ResponseRate_ini.ToString();
            identifyCode_tb.Text = model.IdentifyCode_ini.ToString();
            disRate_tb.Text = model.DistanceRate_ini.ToString();
            azRate_tb.Text = model.AzimuthRate_ini.ToString();
            display.SetDmeState(model.Azimuth_ini, model.Distance_ini);
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
        }

        private void Dis_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0d)
            {
                display.Distance = double.Parse(dis_tb.Text);
                dis_tb.SelectAll();
            }
        }

        private void Az_tb_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 0x0d)
            {
                display.Az = double.Parse(az_tb.Text);
                az_tb.SelectAll();
            }
        }

        private void Confirm_btn_Click(object sender, EventArgs e)
        {
            if(!validation.IsAllInputsValidate())
            {
                validation.Cue();
                ShowHint();
                return;
            }
            controller.SetAzimuth(double.Parse(az_tb.Text));
            controller.SetDistance(double.Parse(dis_tb.Text));
            controller.SetResponsePower(double.Parse(responsePower_tb.Text));
            controller.SetChannel(uint.Parse(channel_tb.Text));
            controller.SetEncodeMode(x_rb.Checked ? EncodeMode.X : EncodeMode.Y);
            controller.SetRandomPulse(uint.Parse(randomPulse_tb.Text));
            controller.SetModulation15(uint.Parse(modulation15_tb.Text));
            controller.SetModulation135(uint.Parse(modulation135_tb.Text));
            controller.SetResponseRate(double.Parse(responseRate_tb.Text));
            controller.SetIdentifyCode(identifyCode_tb.Text);
            controller.SetAzimuthRate(double.Parse(azRate_tb.Text));
            controller.SetDistanceRate(double.Parse(disRate_tb.Text));

            controller.CommitChanges();
        }

        private void ShowHint()
        {
            var timer = new Timer
            {
                Interval = 3000
            };
            timer.Tick += Timer_Tick;
            timer.Start();
            hint_lab.Text = "存在不合法输入";
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            var t = sender as Timer;
            t.Tick -= Timer_Tick;
            t.Dispose();
            hint_lab.Text = "";
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            responsePower_tb.Text = responsePower_tkb.Value.ToString();
        }
    }
}
