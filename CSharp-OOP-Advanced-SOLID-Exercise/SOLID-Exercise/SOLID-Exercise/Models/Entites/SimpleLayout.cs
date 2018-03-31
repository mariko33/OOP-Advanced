using System.Globalization;
using SOLID_Exercise.Models.Contracts;

namespace SOLID_Exercise.Models.Entites
{
    public class SimpleLayout : ILayout
    {
        //error.DateTime - error.Level - error.Message
        const string Format = "{0} - {1} - {2}";

        const string DateFormat = "M/d/yyyy h:mm:ss tt";

        public string FormatError(IError error)
        {
            string dateString = error.DataTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string formatedError = string.Format(Format, dateString, error.Level.ToString(), error.Message);
            return formatedError;
        }
    }
}