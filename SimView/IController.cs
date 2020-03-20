using FPGADrives;
using System;
using IFTransceiverDrives;

namespace SimView
{
    public interface ITacanController
    {
        TacanModel Model { get; }
        void SetChannel(uint channelNumber);
        void SetEncodeMode(EncodeMode encodeMode);
        void SetAzimuth(double az);
        void SetDistance(double dis);
        void SetDistanceRate(double disRate);
        void SetAzimuthRate(double azRate);
        void SetRandomPulse(uint number);
        void SetModulation15(uint percentage);
        void SetModulation135(uint percentage);
        void SetResponsePower(double power);
        void SetResponseRate(double rate);
        void SetIdentifyCode(string code);
        void CommitChanges();

        void Write(int address, int data);
    }

    public enum EncodeMode
    {
        X,
        Y
    }

    class PXES2590Controller : ITacanController
    {
        private JXI750xDrive ifTransceiver = new JXI750xDrive();
        private FPGADrive fpga = FPGADrive.GetInstance();
        public PXES2590Controller(TacanModel model)
        {
            Model = model;
        }

        public TacanModel Model { get; private set; }

        public void SetAzimuth(double az) => Model.Azimuth_ini = az;

        public void SetAzimuthRate(double azRate) => Model.AzimuthRate_ini = azRate;

        public void SetChannel(uint channelNumber) => Model.Channel_ini = channelNumber;
        public void SetEncodeMode(EncodeMode encodeMode)
        {
            Model.EncodeMode_ini = encodeMode == EncodeMode.X ? "x" : "y";
            Model.EncodeMode = encodeMode;
        }

        private double CalFrequency(EncodeMode type, uint channel)
        {
            switch (type)
            {
                case EncodeMode.X:
                    return CalXFrequency(channel);
                case EncodeMode.Y:
                    return CalYFrequency(channel);
                default:
                    throw new Exception($"错误的EncodeType类型:{type}");
            }
        }

        private double CalXFrequency(uint channel)
        {
            if(channel <= 63)
            {
                return (961 + channel)*1E6;
            }
            else
            {
                return (1087 + channel)*1E6; //1151 + (channel - 64)
            }
        }

        private double CalYFrequency(uint channel)
        {
            if (channel <= 63)
            {
                return (1087 + channel)*1E6;
            }
            else
            {
                return (961 + channel)*1E6; //1025 + (channel - 64)
            }
        }

        public void SetDistance(double dis) => Model.Distance_ini = dis;

        public void SetDistanceRate(double disRate) => Model.DistanceRate_ini = disRate;

        public void SetIdentifyCode(string code) => Model.IdentifyCode_ini = code;

        public void SetModulation135(uint percentage) => Model.Modulation135_ini = percentage;

        public void SetModulation15(uint percentage) => Model.Modulation15_ini = percentage;

        public void SetRandomPulse(uint number) => Model.RandomPulse_ini = number;

        public void SetResponsePower(double power) => Model.ResponsePower_ini = power;

        public void SetResponseRate(double rate) => Model.ResponseRate_ini = rate;

        public void CommitChanges()
        {
            var freq = CalFrequency(Model.EncodeMode, Model.Channel_ini);
            ifTransceiver.SetFrequencyAndPower(freq, Model.ResponsePower_ini);
        }

        public void Write(int address, int data)
        {
            fpga.Write(address, data);
        }
    }
}