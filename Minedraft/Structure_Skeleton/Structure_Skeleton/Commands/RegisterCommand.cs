
using System.Collections.Generic;
using System.Linq;

public class RegisterCommand : Command
{
    public RegisterCommand(IList<string> arguments, IHarvesterController harvesterController, IProviderController providerController) 
        : base(arguments)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;

    }

    public IHarvesterController HarvesterController { get; private set; }
    public IProviderController ProviderController { get; private set; }

    public override string Execute()
    {
        string typeOfRegister = this.Arguments[0];
        List<string> args = this.Arguments.Skip(1).ToList();
        
        if (typeOfRegister == "Harvester")
        {
           return this.HarvesterController.Register(args);
        }
        else if(typeOfRegister== "Provider")
        {
            return this.ProviderController.Register(args);
        }

        return "Invalid Entity to Register";
    }
}
