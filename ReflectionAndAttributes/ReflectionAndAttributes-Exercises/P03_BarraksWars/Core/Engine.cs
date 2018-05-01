using System.Linq;
using System.Reflection;

namespace _03BarracksFactory.Core
{
    using System;
    using Contracts;

    class Engine : IRunnable
    {
        private IRepository repository;
        private IUnitFactory unitFactory;

        public Engine(IRepository repository, IUnitFactory unitFactory)
        {
            this.repository = repository;
            this.unitFactory = unitFactory;
        }
        
        public void Run()
        {
            while (true)
            {
                try
                {
                    string input = Console.ReadLine();
                    string[] data = input.Split();
                    string commandName = data[0];
                    string result = InterpredCommand(data, commandName);
                    Console.WriteLine(result);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        // TODO: refactor for Problem 4
        private string InterpredCommand(string[] data, string commandName)
        {
            string result = string.Empty;
            
            Assembly assembly=Assembly.GetExecutingAssembly();
            Type commandType = assembly
                .GetTypes()
                .FirstOrDefault(t => t.Name.ToLower() == commandName + "command");
            
            if(commandType==null)throw new ArgumentException("Invalid command");

            if (!typeof(IExecutable).IsAssignableFrom(commandType))
            {
                throw new ArgumentException("Coomand name is not command");
            }

            MethodInfo method = typeof(IExecutable).GetMethods().First();

            Object[] ctorArgs = new object[] {data, this.repository, this.unitFactory};
            IExecutable instance = (IExecutable)Activator.CreateInstance(commandType,ctorArgs);
            try
            {
                result = (string)method.Invoke(instance, null);
            
                return result;
            }
            catch (Exception e)
            {
                throw e.InnerException;
            }
        }


       
    }
}
