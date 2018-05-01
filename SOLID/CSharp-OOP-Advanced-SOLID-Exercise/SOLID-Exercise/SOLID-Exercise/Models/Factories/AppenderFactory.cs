using System;
using SOLID_Exercise.Models.Contracts;
using SOLID_Exercise.Models.Entites;
using SOLID_Exercise.Models.Enums;
using SOLID_Exercise.Utilities;

namespace SOLID_Exercise.Models.Entites
{
    public class AppenderFactory
    {
        private const string DefaultFileName = "logFile{0}.txt";
        
        private LayoutFactory layoutFactory;
        private Helpers helpers;
        private int fileNumber;
        
        public AppenderFactory(LayoutFactory layoutFactory)
        {
            this.layoutFactory = layoutFactory;
            this.helpers=new Helpers();
            this.fileNumber = 0;
        }

        public IAppender CreateAppender(string appenderType, string levelString,string layoutType)
        {
            ILayout layout = layoutFactory.CreateLayout(layoutType);
            ErrorLevel errorLevel = helpers.ParseLevelError(levelString);

            IAppender appender = null;
            
            switch (appenderType)
            {
                case "ConsoleAppender":appender=new ConsoleAppender(layout,errorLevel);
                    break;
                case "FileAppender":
                    ILogFile logFile=new LogFile(string.Format(DefaultFileName,this.fileNumber));
                    appender = new FileAppender(layout, errorLevel, logFile);
                    break;
                default:throw new ArgumentException("Invalid appender type!");
                
                    
            }

            return appender;

        }

        
    }
}