using System;

namespace FestivalManager.Entities.Sets
{
    public class Long:Set
    {
        public Long(string name) 
            : base(name, new TimeSpan(0,1,0,0))
        {
        }
    }
}