using BashSoftProject.Attributes;
using BashSoftProject.Contracts;
using BashSoftProject.Exceptions;
using BashSoftProject.Judge;
using BashSoftProject.Repository;

namespace BashSoftProject.IO.Commands
{
    [Alias("mkdir")]
    public class MakeDirectoryCommand:Command
    {
        [Inject] private IDirectoryManager inputOutputManager;

        public MakeDirectoryCommand(string input, string[] data)
            : base(input, data)
        {
        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var folderName = this.Data[1];
            this.inputOutputManager.CreateDirectoryInCurrentFolder(folderName);
        }
    }
}