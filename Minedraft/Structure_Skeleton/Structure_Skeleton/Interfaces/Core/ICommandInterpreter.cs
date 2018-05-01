using System.Collections.Generic;

public interface ICommandInterpreter
{
    IHarvesterController HarvesterController { get; }

    IProviderController ProviderController { get; }

    string ProcessCommand(List<string> args);
}