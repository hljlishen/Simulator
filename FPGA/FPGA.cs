using JXI750x;
using System;

namespace FPGADrives
{
    public class FPGADrive : IDisposable
    {
        private const string DllPathName = "RFCore.dll";
        private static FPGADrive instance = null;
        private readonly static object locker = new object();
        private JXI750xAWGTask aotask;
        private JXI750xDigitizerTask aiTask;
        public int CardID { get; private set; }
        public int SlotNumber { get; set; } = 0;

        [System.Runtime.InteropServices.DllImport(DllPathName, EntryPoint = "RFCore_Init", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        private static extern int RFCore_Init(int slotNumber, ref int cardID);

        [System.Runtime.InteropServices.DllImport(DllPathName, EntryPoint = "RFCore_WriteReg", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        private static extern int RFCore_WriteReg(int cardID, int address, int dataSource);

        [System.Runtime.InteropServices.DllImport(DllPathName, EntryPoint = "RFCore_ReadReg", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        private static extern int RFCore_ReadReg(int cardID, int address, ref int dataOut);

        [System.Runtime.InteropServices.DllImport(DllPathName, EntryPoint = "RFCore_Close", CallingConvention = System.Runtime.InteropServices.CallingConvention.StdCall)]
        private static extern int RFCore_Close(int cardID);

        private FPGADrive()
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

            int cardID = 0;
            int result = RFCore_Init(SlotNumber, ref cardID);
            CardID = cardID;
        }

        public static FPGADrive GetInstance()
        {
            if(instance == null)
            {
                lock(locker)
                {
                    if(instance == null)
                    {
                        instance = new FPGADrive();
                    }
                }
            }

            return instance;
        }

        public int Read(int address, out int ret)
        {
            ret = int.MaxValue;
            var result = RFCore_ReadReg(CardID, address, ref ret);

            return result;
        }

        public void Write(int address, int data)
        {
            RFCore_WriteReg(CardID, address, data);
        }

        public void Dispose()
        {
            RFCore_Close(CardID);
        }
    }
}
