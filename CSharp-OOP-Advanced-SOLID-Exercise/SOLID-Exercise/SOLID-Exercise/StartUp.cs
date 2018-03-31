using System;
using System.Collections.Generic;
using SOLID_Exercise.Models.Contracts;
using SOLID_Exercise.Models.Entites;
using SOLID_Exercise.Models.Enums;
using SOLID_Exercise.Models.Entites;

namespace SOLID_Exercise
{
    public class StartUp
    {
        public static void Main()
        {
            ILogger logger = InitializeLogger();
            ErrorFactory errorFactory=new ErrorFactory();
            Engine engine=new Engine(logger,errorFactory);
            engine.Run();
        }

        public static ILogger InitializeLogger()
        {
            ICollection<IAppender> appenders = new List<IAppender>();
            LayoutFactory layoutFactory = new LayoutFactory();
            AppenderFactory appenderFactory = new AppenderFactory(layoutFactory);


            int appenderCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < appenderCount; i++)
            {
                string[] args = Console.ReadLine().Split();

                string appendType = args[0];
                string layoutType = args[1];
                string errorLevel = "INFO";

                if (args.Length==3)
                {
                    errorLevel = args[2];
                }

                IAppender appender = appenderFactory.CreateAppender(appendType, errorLevel, layoutType);
                appenders.Add(appender);
            }
            
            ILogger logger=new Logger(appenders);
            return logger;
        }
    }
}
