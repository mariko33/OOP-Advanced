using System;
using SOLID_Exercise.Models.Contracts;
using SOLID_Exercise.Models.Enums;

namespace SOLID_Exercise.Models.Entites
{
    public class Error:IError
    {
        public Error(DateTime dateTime, ErrorLevel level,string message)
        {
            this.DataTime = dateTime;
            this.Level = level;
            this.Message = message;
            
        }
        
        public DateTime DataTime { get;  }
        public string Message { get;  }
        public ErrorLevel Level { get;  }
    }
}