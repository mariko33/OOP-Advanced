using System.Diagnostics;
using BashSoftProject.Attributes;
using BashSoftProject.Contracts;
using BashSoftProject.Exceptions;
using BashSoftProject.Judge;
using BashSoftProject.Repository;
using BashSoftProject.Static_data;

namespace BashSoftProject.IO.Commands
{
    [Alias("open")]
    public class OpenFileCommand:Command
    {
        public OpenFileCommand(string input, string[] data)
            : base(input, data)
        {

        }

        public override void Execute()
        {
            if (this.Data.Length != 2)
            {
                throw new InvalidCommandException(this.Input);
            }

            var filename = this.Data[1];
            Process.Start(SessionData.currentPath + "\\" + filename);
        }
    }
}