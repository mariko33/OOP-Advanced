public class Tesla:ICar,IElectricCar
{
    public Tesla(string model, string color, int battery)
    {
        this.Model = model;
        this.Color = color;
        this.Battery = battery;
    }
    
    public string Model { get; private set; }
    public string Color { get; private set; }
    
    public string Start()
    {
        return $"Engine start";
    }

    public string Stop()
    {
        return $"Breaaak!";
    }

    public int Battery { get; private set; }

    public override string ToString()
    {
        return $"Red {this.GetType().Name}  {this.Model} with {this.Battery} Batteries";
    }
}
