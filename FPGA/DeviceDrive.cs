using JXI.RF.Device.IFTransceiver;
using JXI.RF.Device.VST;
using System.Collections.Generic;
using System.Threading;

namespace FPGA
{
    public class DeviceDrive
    {
        private VectorSignalTranceiver device;
        private StandardSignalGenTask standardGenTask;

        public DeviceDrive()
        {
            var dcNames = new List<string>() { "10001AF3" };
            var ucnames = new List<string>() { "10001713" };
            device = new VectorSignalTranceiver(ifTranceiverModel: Model.JXI750x, ifTranceiverName: "6", downconverterModel: JXI.RF.Device.Downconverter.Model.PXIe7660, downconverterNames: dcNames, upconverterModel: JXI.RF.Device.Upconverter.Model.PXIe7760, upconverterNames: ucnames);
            // 加载频率和功率校准文件
            //device.Correction.LoadFromFile("D:\\software\\vst-appdriver\\CSharp Source\\Test Panel\\VST Generation and Analysis Test Panel\\bin\\Debug\\Calibration Of VST.ini");

            // 设置中频模块的参考时钟、基准时钟速率等参数。
            device.IFTranceiver.ClockSource = ClockSource.Internal;
            device.IFTranceiver.TimebaseRate = 240.0 * 1E6; //TimeRate base

            device.Downconverters[0].Clock.Source = JXI.RF.Device.Downconverter.ClockSource.Internal;
            device.Downconverters[0].Clock.Output = JXI.RF.Device.Downconverter.ClockOutput.None;

            device.Upconverters[0].Clock.Source = JXI.RF.Device.Upconverter.ClockSource.Internal;
            device.Upconverters[0].Clock.Output = JXI.RF.Device.Upconverter.ClockOutput.None;
        }

        public void SetFrequencyAndPower(double frequency, double outputPower)
        {
            //if (standardGenTask != null && standardGenTask.IsRunning)
            //{
            //    standardGenTask.Stop();

            //}
            standardGenTask = new StandardSignalGenTask(device);
            // 添加通道，各通道可以有不同的Frequency / Reference Level。
            standardGenTask.AddChannel(0, frequency, outputPower);
            standardGenTask.Start();
        }
    }
}
