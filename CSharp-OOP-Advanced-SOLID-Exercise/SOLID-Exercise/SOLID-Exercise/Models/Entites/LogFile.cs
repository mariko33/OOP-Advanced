using System;
using System.IO;
using SOLID_Exercise.Models.Contracts;

namespace SOLID_Exercise.Models.Entites
{
    public class LogFile:ILogFile
    {
        private const string DefaultPath = "./Data/"; //./data/;../../../Data/

        public LogFile(string fileName)
        {
            this.Path = DefaultPath + fileName;
            File.AppendAllText(this.Path,"");
            this.Size = 0;
        }
        public string Path { get; }
        public int Size { get; private set; }
        public void WriteToFile(string errorLog)
        {
          
            File.AppendAllText(this.Path,errorLog+Environment.NewLine);

            int addedSize = 0;

            for (int i = 0; i < errorLog.Length; i++)
            {
                addedSize += errorLog[i];
            }

            this.Size += addedSize;
        }
    }
}