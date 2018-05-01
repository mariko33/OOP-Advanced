using System;
using BashSoftProject.Contracts;
using BashSoftProject.IO;
using BashSoftProject.Judge;
using BashSoftProject.Repository;

namespace BashSoftProject
{
    class StartUp
    {
        static void Main()
        {
            IContentComparer tester = new Tester();
            IDirectoryManager ioManager = new IOManager();
            IDatabase repo = new StudentsRepository(new RepositoryFilter(), new RepositorySorter());

            IInterpreter currentInterpreter = new CommandInterpreter(tester, repo, ioManager);
            IReader reader = new InputReader(currentInterpreter);

            reader.StartReadingCommands();
        }
    }
}
