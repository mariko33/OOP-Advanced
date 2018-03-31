using System;
using System.Globalization;
using SOLID_Exercise.Models.Contracts;
using SOLID_Exercise.Models.Entites;
using SOLID_Exercise.Models.Enums;
using SOLID_Exercise.Utilities;

namespace SOLID_Exercise.Models.Entites
{
    public class ErrorFactory
    {
        private Helpers helpers;

        public ErrorFactory()
        {
            this.helpers=new Helpers();
        }
        
        const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public IError CreateError(string dateTimeString, string errorLevelString, string message)
        {
            DateTime dateTime=DateTime.ParseExact(dateTimeString,DateFormat,CultureInfo.InvariantCulture);
            ErrorLevel errorLevel = helpers.ParseLevelError(errorLevelString);
            IError error=new Error(dateTime,errorLevel,message);
            
            
            return error;
        }
    }
}