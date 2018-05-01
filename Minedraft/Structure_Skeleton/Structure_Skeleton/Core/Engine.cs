using System;
using System.Collections.Generic;
using System.Linq;

public class Engine
{
    private ICommandInterpreter commandInterpreter;
    private IReader reader;
    private IWriter writer;

    public Engine(ICommandInterpreter commandInterpreter, IReader reader, IWriter writer)
    {
        this.commandInterpreter = commandInterpreter;
        this.reader = reader;
        this.writer = writer;
    }

    public void Run()
    {
    
        while (true)
        {
            var inputArgs = reader.ReadLine().Split().ToList();

            string result = this.commandInterpreter.ProcessCommand(inputArgs);
            
            writer.WriteLine(result);
            if (result.Contains(Constants.SystemShutDown)) 
                break;
        }


    }
}
