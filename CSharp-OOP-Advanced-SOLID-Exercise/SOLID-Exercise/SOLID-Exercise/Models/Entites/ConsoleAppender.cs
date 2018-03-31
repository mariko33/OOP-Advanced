using System;
using SOLID_Exercise.Models.Contracts;
using SOLID_Exercise.Models.Enums;

namespace SOLID_Exercise.Models.Entites
{
    public class ConsoleAppender:IAppender
    {
        public ConsoleAppender(ILayout layout, ErrorLevel level)
        {
            this.Layout = layout;
            this.Level = level;
            this.MessagesAppended = 0;
        }
        
        public ILayout Layout { get; private set; }
        public ErrorLevel Level { get; private set; }
        
        public int MessagesAppended { get; private set; }
        
        
        public void Append(IError error)
        {
            string formatedError = this.Layout.FormatError(error);
            Console.WriteLine(formatedError);
            this.MessagesAppended++;
        }

        public override string ToString()
        {
            string result = $"Appender type: {this.GetType().Name}, Layout type: {this.Layout.GetType().Name}, " +
                            $"Report level: {this.Level}, Messages appended: {this.MessagesAppended}";
            return result;
        }
    }
}