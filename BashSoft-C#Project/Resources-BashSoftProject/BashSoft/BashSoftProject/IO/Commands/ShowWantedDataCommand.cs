﻿using BashSoftProject.Attributes;
using BashSoftProject.Contracts;
using BashSoftProject.Exceptions;
using BashSoftProject.Judge;
using BashSoftProject.Repository;

namespace BashSoftProject.IO.Commands
{
    [Alias("show")]
    public class ShowWantedDataCommand:Command
    {
        [Inject]
        private IDatabase repository;

        public ShowWantedDataCommand(string input, string[] data)
            : base(input, data) { }

        public override void Execute()
        {
            if (this.Data.Length == 2)
            {
                var course = this.Data[1];
                this.repository.GetAllStudentsFromCourse(course);
            }
            else if (this.Data.Length == 3)
            {
                var course = this.Data[1];
                var username = this.Data[2];
                this.repository.GetStudentScoresFromCourse(course, username);
            }
            else
            {
                throw new InvalidCommandException(this.Input);
            }
        }
    }
}