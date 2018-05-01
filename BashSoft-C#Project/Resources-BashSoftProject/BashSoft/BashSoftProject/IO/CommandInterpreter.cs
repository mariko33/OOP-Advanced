using System;
using System.Linq;
using System.Reflection;
using BashSoftProject.Attributes;
using BashSoftProject.Contracts;
using BashSoftProject.Exceptions;
using BashSoftProject.IO.Commands;
using BashSoftProject.Judge;
using BashSoftProject.Repository;

namespace BashSoftProject.IO
{
    public class CommandInterpreter : IInterpreter
    {
        private IContentComparer judge;
        private IDatabase repository;
        private IDirectoryManager inputOutputManager;

        public CommandInterpreter(IContentComparer judge, IDatabase repository, IDirectoryManager inputOutputManager)
        {
            this.judge = judge;
            this.repository = repository;
            this.inputOutputManager = inputOutputManager;
        }

        public void InterpretCommand(string input)
        {
            string[] data = input.Split();
            string commandName = data[0];

            try
            {
                IExecutable command = this.ParseCommand(input, commandName, data);
                command.Execute();
            }
            catch (Exception e)
            {
                OutputWriter.DisplayException(e.Message);
            }
        }

        private IExecutable ParseCommand(string input, string command, string[] data)
        {

            object[] parametersForConstruction = new object[]
            {
                input, data
            };

            Type typeOfCommand = Assembly
                .GetExecutingAssembly()
                .GetTypes()
                .First(type => type
                                   .GetCustomAttributes(typeof(AliasAttribute))
                                   .Where(atr => atr.Equals(command))
                                   .ToArray()
                                   .Length > 0);

            Type typeOfInterpreter = typeof(CommandInterpreter);

            Command exe = (Command)Activator
                .CreateInstance(typeOfCommand, parametersForConstruction);

            FieldInfo[] fieldsOfCommand = typeOfCommand
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            FieldInfo[] fieldsOfInterpreter = typeOfInterpreter
                .GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

            foreach (var fieldOfCommand in fieldsOfCommand)
            {
                Attribute atrAttribute = fieldOfCommand
                    .GetCustomAttribute(typeof(InjectAttribute));

                if (atrAttribute != null)
                {
                    if (fieldsOfInterpreter.Any(f => f.FieldType == fieldOfCommand.FieldType))
                    {
                        fieldOfCommand.SetValue(
                            exe,
                            fieldsOfInterpreter
                                .First(f => f.FieldType == fieldOfCommand.FieldType)
                                .GetValue(this));
                    }
                }
            }

            return exe;

            //switch (command)
            //{
            //    case "open":
            //        return new OpenFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "mkdir":
            //        return new MakeDirectoryCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "ls":
            //        return new TraverseFoldersCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "cmp":
            //        return new CompareFilesCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "cdRel":
            //        return new ChangePathRelativelyCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "cdAbs":
            //        return new ChangePathAbsoluteCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "readDb":
            //        return new ReadDatabaseFromFileCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "help":
            //        return new GetHelpCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "filter":
            //        return new FilterAndTakeCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "order":
            //        return new OrderAndTakeCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "dropdb":
            //        return new DropDbCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "show":
            //        return new ShowWantedDataCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    case "display":
            //        return new DisplayCommand(input, data, this.judge, this.repository, this.inputOutputManager);
            //    break;
            //    //case "decOrder":
            //    //    break;
            //    //case "download":
            //    //    break;
            //    //case "downloadAsynch":
            //    //    break;
            //    default:
            //        throw new InvalidCommandException(input);
            //}
        }
    }
}