using System.Collections.Generic;

namespace BashSoftProject.Contracts
{
    public interface IDataSorter
    {
        void OrderAndTake(Dictionary<string, double> studentsWithMark, string comparison, int studentsToTake);
    }
}