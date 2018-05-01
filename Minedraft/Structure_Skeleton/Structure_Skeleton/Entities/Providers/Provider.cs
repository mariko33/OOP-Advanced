using System.Text;

public class Provider : IProvider
{

    private const double DurabilityStart = 1000;
    private const double DurabilityBroke = 100;

    public Provider(int id, double energyOutput)
    {
        this.ID = id;
        this.Durability = DurabilityStart;
        this.EnergyOutput = energyOutput;
    }

    public int ID { get; }
    public double Durability { get; protected set; }
    public double EnergyOutput { get; }



    public double Produce()
    {
        return this.EnergyOutput;
    }

    public void Broke()
    {
        if (this.Durability >= 0)
            this.Durability -= DurabilityBroke;

    }

    public void Repair(double val)
    {
        this.Durability += val;
    }

    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(this.GetType().Name)
            .AppendLine($"Durability: {this.Durability}");
        return sb.ToString().Trim();

    }
}