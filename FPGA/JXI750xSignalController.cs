using JXIPXIe7660;
using JXIPXIe7760;
using System;
using System.Linq;

namespace IFTransceiverDrives
{
    public class JXI750xSignalController : ISignalController
    {
        private PXIe7760 upConverter;
        private PXIe7660 downConverter;

        public JXI750xSignalController()
        {
            upConverter = new PXIe7760(PXIe7760.ListDevices().First());
            upConverter.Clock.Source = JXIPXIe7760.ClockSource.Internal;
            upConverter.Clock.Output = JXIPXIe7760.ClockOutput.None;
            upConverter.IFInput.Path = IFInputPath.ThirdStage;
            upConverter.IFInput.Frequency = 70 * 1E6;
            upConverter.IFInput.Level = 0;
            upConverter.RFOutput.Bypass = false;
            upConverter.RFOutput.Frequency = 2450E6;
            upConverter.RFOutput.Level = 0;

            downConverter = new PXIe7660(PXIe7660.ListDevices().First());
            downConverter.Clock.Source = JXIPXIe7660.ClockSource.Internal;
            downConverter.Clock.Output = JXIPXIe7660.ClockOutput.None;
            downConverter.RFInput.Bypass = false;
            downConverter.RFInput.ReferenceLevel = 0;   //???
            downConverter.IFOutput.Path = IFOutputPath.ThirdStage;
            downConverter.IFOutput.Frequency = 70E6;
            downConverter.IFOutput.Level = 0;
            downConverter.IFOutput.Bandwidth = 40E6;
        }
        public void SetUpConverterState(double frequency, double outputPower)
        {
            upConverter.RFOutput.Frequency = frequency;
            upConverter.RFOutput.Level = outputPower;
        }

        public void SetDownConverterState(double frequency, double outputPower)
        {
            downConverter.RFInput.Frequency = frequency;
            downConverter.IFOutput.Level = outputPower;
        }
    }
}
