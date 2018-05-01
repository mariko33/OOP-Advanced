public class Ferrari:ICar
{

    public Ferrari(string driverName)
    {
        this.DriverName = driverName;
        this.Model = "488-Spider";
    }
    
    public string DriverName { get; private set; }
    public string Model { get; private set; }
    public string UseBrakes()
    {
        return "Brakes!";
    }

    public string PushTheGasPedal()
    {
        return "Zadu6avam sA!";
    }

    public override string ToString()
    {
        return $"{this.Model}/{this.UseBrakes()}/{this.PushTheGasPedal()}/{this.DriverName}";
    }
}
