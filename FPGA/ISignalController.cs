namespace IFTransceiverDrives
{
    public interface ISignalController
    {
        void SetUpConverterState(double frequency, double outputPower);
        void SetDownConverterState(double frequency, double outputPower);
    }
}