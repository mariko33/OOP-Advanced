using System;
using SOLID_Exercise.Models.Enums;

namespace SOLID_Exercise.Models.Contracts
{
    public interface IError
    {
        DateTime DataTime { get; }
        
        string Message { get; }
        
        ErrorLevel Level { get; }
    }
}