using System.Collections.Generic;
using System.ComponentModel;

namespace SOLID_Exercise.Models.Contracts
{
    public interface ILogger
    {
        IReadOnlyCollection<IAppender> Appenders { get; }
        
        void Log(IError error);
    }

    
}