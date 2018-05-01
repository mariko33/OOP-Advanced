using System;
using BashSoftProject.Contracts;
using BashSoftProject.Exceptions;
using BashSoftProject.Judge;
using BashSoftProject.Repository;

namespace BashSoftProject.IO.Commands
{
    public abstract class Command:IExecutable
    {
        private string input;
        private string[] data;

        //private IContentComparer judge;
        //private IDatabase repository;
        //private IDirectoryManager inputOutputManager;

        public Command(string input, string[] data)
        {
            this.Input = input;
            this.Data = data;
            //this.judge = judge;
            //this.repository = repository;
            //this.inputOutputManager = inputOutputManager;
        }

        public string[] Data
        {
            get { return this.data; }
            private set
            {
                if (value == null || value.Length == 0)
                {
                    throw new NullReferenceException();
                }
                this.data = value;
            }
        }

        public string Input
        {
            get { return this.input; }
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new InvalidStringException();
                }
                this.input = value;
            }
        }

       
        public abstract void Execute();
    }
}