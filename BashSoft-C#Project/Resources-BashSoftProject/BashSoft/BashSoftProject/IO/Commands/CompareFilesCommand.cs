﻿using BashSoftProject.Attributes;
using BashSoftProject.Contracts;
using BashSoftProject.Exceptions;
using BashSoftProject.Judge;
using BashSoftProject.Repository;

namespace BashSoftProject.IO.Commands
{
    [Alias("cmp")]
    public class CompareFilesCommand:Command
    {
        [Inject]
        private IContentComparer judge;

        public CompareFilesCommand(string input, string[] data)
            : base(input, data) { }

        public override void Execute()
        {
            if (this.Data.Length != 3)
            {
                throw new InvalidCommandException(this.Input);
            }

            this.judge.CompareContent(this.Data[1], this.Data[2]);
        }
    }
}