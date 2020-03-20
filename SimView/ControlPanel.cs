using System;
using System.Windows.Forms;
using FPGA;
using JXI750x;
using JXIPXIe7660;
using JXIPXIe7760;
using Mapper;
using PPI;

namespace SimView
{
    public partial class ControlPanel : Form
    {
        private JXI750xAWGTask aotask;
        private JXI750xDigitizerTask aiTask;
        private PPIDisplay display;
        private IScreenToCoordinateMapper mapper;
        private IDeviceController controller;
        public ControlPanel(IDeviceController controller)
        {
            InitializeComponent();

            mapper = new SquaredScreenRectDecorator(new ScreenToCoordinateMapper());
            display = new PPIDisplay(ppi_pb, mapper);
            //var dd = new DeviceDrive();
            //dd.SetFrequencyAndPower(1000 * 1E6, 0);

            display.DmeStateChanged += Display_DmeStateChanged;
            this.controller = controller;
            UpdateForm(controller.Model);
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
            //responsePower_tb.Text = model.ResponsePower_ini.ToString();
            trackBar1.Value = (int)model.ResponsePower_ini;
            display.SetDmeState(model.Azimuth_ini, model.Distance_ini);
        }

        private void ControlPanel_Load(object sender, EventArgs e)
        {
            aotask = new JXI750xAWGTask(0);
            aotask.Mode = AOMode.ContinuousWrapping;
            aotask.SampleRate = 20e6;
            aotask.WaveformLength = 10 * 1024;
            aotask.TimeBaseRate = 250e6; //强制250MS/s
            aotask.EnableDUC = true;
            aotask.DataFormat = DataFormat.Complex;
            //if (checkBox1.Checked)
            //{
            aotask.AddChannel(-1, 70e6, 1.0, 0);
            //}
            //else
            //{
            //    aotask.AddChannel(0, (double)numIFCenterFreq.Value * 1e6, 1.0, 0);
            //}

            aotask.Commit();
            aiTask = new JXI750xDigitizerTask(0);
            aiTask.SampleRate = 20e6;
            //FPGADrive.FPGA fpga = FPGADrive.FPGA.GetInstance();
            //fpga.Write(0x54008, 10);
            //fpga.Write(0x54000, 11);
            //fpga.Write(0x54004, 12);
            //int ret;
            //while (true)
            //    _ = fpga.Read(0x54008, out ret);
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
            controller.SetAzimuth(double.Parse(az_tb.Text));
            controller.SetDistance(double.Parse(dis_tb.Text));
            controller.SetResponsePower(double.Parse(responsePower_tb.Text));   //SetResponsePower要在SetChannel之前
            controller.SetChannel(uint.Parse(channel_tb.Text));
            controller.SetEncodeMode(x_rb.Checked ? EncodeType.X : EncodeType.Y);

            controller.CommitChanges();
        }

        private void TrackBar1_ValueChanged(object sender, EventArgs e)
        {
            responsePower_tb.Text = trackBar1.Value.ToString();
        }
    }
}
