﻿using System;


public class Program
{
    public static void Main(string[] args)
    {
        IEnergyRepository energyRepository = new EnergyRepository();

        IReader reader=new Reader();
        IWriter writer=new Writer();
        
        IHarvesterController harvesterController=new HarvesterController(energyRepository);
        IProviderController providerController=new ProviderController(energyRepository);
        ICommandInterpreter commandInterpreter=new CommandInterpreter(harvesterController,providerController);

        Engine engine = new Engine(commandInterpreter, reader,writer);
        engine.Run();
    }

    
}