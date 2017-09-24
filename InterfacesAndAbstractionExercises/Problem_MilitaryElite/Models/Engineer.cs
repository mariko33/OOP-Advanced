using System;
using System.Collections.Generic;
using System.Text;

public class Engineer:SpecialisedSoldier,IEngineer
{
    public Engineer(int id, string fistName, string lastName, double salary, string corp, List<IRepair>pairs) : base(id, fistName, lastName, salary, corp)
    {
        this.PartNameWorkingHours = pairs;
    }

    public List<IRepair> PartNameWorkingHours { get; set; }

    public override string ToString()
    {
        StringBuilder sb=new StringBuilder();
        foreach (var pair in this.PartNameWorkingHours)
        {
            sb.Append(Environment.NewLine + "  "+pair);
        }
        
        return base.ToString()+Environment.NewLine+ "Repairs:"+sb;
    }
}
