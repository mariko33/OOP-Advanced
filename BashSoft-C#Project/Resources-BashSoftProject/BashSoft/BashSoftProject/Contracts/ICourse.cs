﻿using System;
using System.Collections.Generic;
using BashSoftProject.Models;

namespace BashSoftProject.Contracts
{
    public interface ICourse:IComparable<ICourse>
    {
        string Name { get; }
        IReadOnlyDictionary<string, IStudent> StudentsByName { get; }
        void EnrollStudent(IStudent student);
    }
}