using System.Collections.Generic;
using SOLID_Exercise.Models.Contracts;

namespace SOLID_Exercise.Models.Entites
{
    public class Logger:ILogger
    {
        private IEnumerable<IAppender> appenders;

        public Logger(IEnumerable<IAppender>appenders)
        {
            this.appenders = appenders;
        }

        public IReadOnlyCollection<IAppender> Appenders => (IReadOnlyCollection<IAppender>)this.appenders;

        public void Log(IError error)
        {
            foreach (IAppender appender in this.appenders)
            {
                if (appender.Level<=error.Level)
                {
                    appender.Append(error);
                }
            }
        }
    }
}