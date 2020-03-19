using System;

namespace FPGADrive
{
    public class FPGA : IDisposable
    {
        private const string DllPathName = "RFCore.dll";
        private static FPGA instance = null;
        private readonly static object locker = new object();
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

        private FPGA()
        {
            int cardID = 0;
            int result = RFCore_Init(SlotNumber, ref cardID);
            CardID = cardID;
        }

        public static FPGA GetInstance()
        {
            if(instance == null)
            {
                lock(locker)
                {
                    if(instance == null)
                    {
                        instance = new FPGA();
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
