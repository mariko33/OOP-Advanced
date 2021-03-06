﻿using System.Collections.Generic;

namespace BashSoftProject.Contracts
{
    public interface IRequester
    {
        void GetStudentScoresFromCourse(string courseName, string username);
        void GetAllStudentsFromCourse(string courseName);

        ISimpleOrderedBag<ICourse> GetAllCoursesSorted(IComparer<ICourse>cmp);

        ISimpleOrderedBag<IStudent> GetAllStudntsSorted(IComparer<IStudent> cmp);
    }
}