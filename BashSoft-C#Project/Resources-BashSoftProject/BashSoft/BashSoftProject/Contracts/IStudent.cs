using System;
using System.Collections.Generic;
using BashSoftProject.Models;

namespace BashSoftProject.Contracts
{
    public interface IStudent:IComparable<IStudent>
    {
        string Username { get; }
        IReadOnlyDictionary<string, ICourse> EnrolledCourses { get; }
        IReadOnlyDictionary<string, double> MarksByCourseName { get; }
        void EnrollInCourse(ICourse course);
        void SetMarkOnCourse(string courseName, params int[] scores);
    }
}