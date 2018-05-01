using System;
using System.Globalization;
using SOLID_Exercise.Models.Contracts;

namespace SOLID_Exercise.Models.Entites
{
    public class XmlLayout : ILayout
    {
        private const string DateFormat = "HH:mm:ss dd-MMM-yyyy";
        
        private string Format =
            "<log>" + Environment.NewLine +
            "\t<date>{0}</date>" + Environment.NewLine +
            "\t<level>{1}</level>" + Environment.NewLine +
            "\t<message>{2}</message>" + Environment.NewLine +
            "</log>";
        
        public string FormatError(IError error)
        {
            string dateString = error.DataTime.ToString(DateFormat, CultureInfo.InvariantCulture);
            string formatedError = string.Format(Format, dateString, error.Level.ToString(), error.Message);
            return formatedError;
        }
    }
}