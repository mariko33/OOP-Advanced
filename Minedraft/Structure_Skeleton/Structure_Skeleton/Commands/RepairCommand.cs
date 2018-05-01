using System.Collections.Generic;

public class RepairCommand : Command
{
    public RepairCommand(IList<string> arguments, IProviderController providerController)
        : base(arguments)
    {
        this.ProviderController = providerController;
    }

    public IProviderController ProviderController { get; private set; }

    public override string Execute()
    {
        double val = double.Parse(this.Arguments[0]);
        return this.ProviderController.Repair(val);
    }
}
