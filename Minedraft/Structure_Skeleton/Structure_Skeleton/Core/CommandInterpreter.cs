
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

public class CommandInterpreter : ICommandInterpreter
{
    private const string ComandSufix = "Command";

    public CommandInterpreter(IHarvesterController harvesterController, IProviderController providerController)
    {
        this.HarvesterController = harvesterController;
        this.ProviderController = providerController;
    }

    public IHarvesterController HarvesterController { get; }
    public IProviderController ProviderController { get; }
  
    public string ProcessCommand(List<string> args)
    {
        ICommand command = this.CreateCommand(args);
        return command.Execute();

        //string commandName = args[0] + ComandSufix;
        //args = args.Skip(1).ToList();

        ////Invoke command
        //Type commandType = Assembly.GetCallingAssembly().GetTypes()
        //    .FirstOrDefault(t => t.Name.Equals(commandName, StringComparison.OrdinalIgnoreCase));

        //var comandParams = new object[]
        //{
        //    args,
        //    this.HarvesterController,
        //    this.ProviderController};

        //ICommand command = (ICommand)Activator.CreateInstance(commandType, comandParams);

        //return command.Execute();

    }

    private ICommand CreateCommand(List<string> args)
    {
        string commandName = args[0];
        args = args.Skip(1).ToList();

        Type commandType = Assembly.GetCallingAssembly()
            .GetTypes()
            .FirstOrDefault(c => c.Name == commandName + "Command");

        if (commandType==null)
        {
            throw new ArgumentException($"{commandName}Command nit found");
        }

        if (!typeof(ICommand).IsAssignableFrom(commandType))
        {
            throw new InvalidOperationException($"{commandName} is not command");
        }

        ConstructorInfo ctorCommandType = commandType.GetConstructors().First();

        ParameterInfo[] ctorParametersInfo = ctorCommandType.GetParameters();
        object[]parameters=new object[ctorParametersInfo.Length];

        for (int i = 0; i < ctorParametersInfo.Length; i++)
        {
            Type typeParameter = ctorParametersInfo[i].ParameterType;

            if (typeParameter == typeof(IList<string>))
                parameters[i] = args;
            else
            {
                PropertyInfo[] propertiesThis = this.GetType().GetProperties();

                PropertyInfo propertyOfThis = propertiesThis
                    .FirstOrDefault(p => p.PropertyType == typeParameter);

                parameters[i] = propertyOfThis.GetValue(this);
                
            }

        }

        ICommand instance = (ICommand)Activator.CreateInstance(commandType, parameters);

        return instance;

    }
}
