using System;
using SOLID_Exercise.Models.Enums;

namespace SOLID_Exercise.Utilities
{
    public class Helpers
    {
        public ErrorLevel ParseLevelError(string levelString)
        {
            try
            {
                object levelObj = Enum.Parse(typeof(ErrorLevel), levelString);
                return (ErrorLevel)levelObj;
            }
            catch (ArgumentException e)
            {
                throw new ArgumentException("Invalid ErrorLevel Type!", e);
            }
        }
    }
}