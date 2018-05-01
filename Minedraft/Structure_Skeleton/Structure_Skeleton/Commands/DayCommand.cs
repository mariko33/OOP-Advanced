
using System.Collections.Generic;
using System.Text;

public class DayCommand : Command
{
    public DayCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController)
        : base(arguments)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; private set; }
    public IProviderController ProviderController { get; private set; }

    public override string Execute()
    {
        StringBuilder sb = new StringBuilder();
        sb.AppendLine(this.ProviderController.Produce());
        sb.AppendLine(this.HarvesterController.Produce());

        return sb.ToString().Trim();
    }
}
