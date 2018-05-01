
using System.Collections.Generic;

public class ModeCommand : Command
{
    public ModeCommand(IList<string> arguments, IHarvesterController harvesterController) 
        : base(arguments)
    {
        this.HarvesterController = harvesterController;
    }

    public IHarvesterController HarvesterController { get; private set; }

    public override string Execute()
    {
        string mode = this.Arguments[0];

        return this.HarvesterController.ChangeMode(mode);
    }
}
