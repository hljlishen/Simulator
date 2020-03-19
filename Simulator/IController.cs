using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Simulator
{
    public interface IDeviceController
    {
        TacanModel Model { get; }
        int SetChannel(uint channelNumber);
        int SetEncodeMode(string mode);
        int SetAzimuth(double az);
        int SetDistance(double dis);
        int SetDistanceRate(double disRate);
        int SetAzimuthRate(double azRate);
        int SetRandomPulse(uint number);
        int SetModulation15(uint percentage);
        int SetModulation135(uint percentage);
        int SetResponsePower(double power);
        int SetResponseRate(double rate);
        int SetIdentifyCode(string code);
    }

    class PXES2590Controller : IDeviceController
    {
        public PXES2590Controller(TacanModel model)
        {
            Model = model;
        }

        public TacanModel Model { get; private set; }

        public int SetAzimuth(double az)
        {
            Model.Azimuth_ini = az;

            return 0;
        }

        public int SetAzimuthRate(double azRate)
        {
            Model.AzimuthRate_ini = azRate;

            return 0;
        }

        public int SetChannel(uint channelNumber)
        {
            Model.Channel_ini = channelNumber;

            return 0;
        }

        public int SetDistance(double dis)
        {
            Model.Distance_ini = dis;

            return 0;
        }

        public int SetDistanceRate(double disRate)
        {
            Model.DistanceRate_ini = disRate;

            return 0;
        }

        public int SetEncodeMode(string mode)
        {
            Model.EncodeMode_ini = mode;

            return 0;
        }

        public int SetIdentifyCode(string code)
        {
            Model.IdentifyCode_ini = code;

            return 0;
        }

        public int SetModulation135(uint percentage)
        {
            Model.Modulation135_ini = percentage;

            return 0;
        }

        public int SetModulation15(uint percentage)
        {
            Model.Modulation15_ini = percentage;

            return 0;
        }

        public int SetRandomPulse(uint number)
        {
            Model.RandomPulse_ini = number;

            return 0;
        }

        public int SetResponsePower(double power)
        {
            Model.ResponsePower_ini = power;

            return 0;
        }

        public int SetResponseRate(double rate)
        {
            Model.ResponseRate_ini = rate;

            return 0;
        }
    }
}
