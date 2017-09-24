public interface ICar
{
    string DriverName { get; }
    string Model { get; }
    string UseBrakes();
    string PushTheGasPedal();
}
