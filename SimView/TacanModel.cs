using IniBind.InterfaceInterception;

namespace SimView
{
    public class TacanModel : IIniBindInterface
    {
        public virtual uint Channel_ini { get; set; }
        public virtual string EncodeMode_ini { get; set; } = "X";
        public virtual double Azimuth_ini { get; set; }
        public virtual double Distance_ini { get; set; }
        public virtual double DistanceRate_ini { get; set; }
        public virtual double AzimuthRate_ini { get; set; }
        public virtual uint RandomPulse_ini { get; set; }
        public virtual uint Modulation15_ini { get; set; }
        public virtual uint Modulation135_ini { get; set; }
        public virtual double ResponsePower_ini { get; set; } = -50;
        public virtual double ResponseRate_ini { get; set; }
        public virtual string IdentifyCode_ini { get; set; } = "ABC";
        public string FilePath => "TacanState.ini";
        public string Section => "TacanState";
        internal EncodeType EncodeType { get; set; }
    }
}
