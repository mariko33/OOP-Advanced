using System.Collections.Generic;

namespace BashSoftProject.Contracts
{
    public interface IDataFilter
    {
        void FilterAndTake(Dictionary<string, double> studentsWithMarks, string wantedFilters, int studentsToTake);
    }
}