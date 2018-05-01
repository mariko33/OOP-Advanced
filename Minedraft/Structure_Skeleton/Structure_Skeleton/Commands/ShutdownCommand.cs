using System.Collections.Generic;
using System.Text;

public class ShutdownCommand:Command
{
    public ShutdownCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }
    public IProviderController ProviderController { get; private set; }

    public override string Execute()
    {
        StringBuilder sb=new StringBuilder();
        sb.AppendLine("System Shutdown")
            .AppendLine($"Total Energy Produced: {this.ProviderController.TotalEnergyProduced}")
            .AppendLine($"Total Mined Plumbus Ore: {this.HarvesterController.OreProduced}");

        return sb.ToString().Trim();
       
    }
}
