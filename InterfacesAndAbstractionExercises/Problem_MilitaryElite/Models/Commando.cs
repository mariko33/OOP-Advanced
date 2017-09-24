using System;
using System.Collections.Generic;
using System.Text;

public class Commando:SpecialisedSoldier,ICommando
{
    
    public Commando(int id, string fistName, string lastName, double salary, string corp, List<IMission>missions) : base(id, fistName, lastName, salary, corp)
    {
        this.Missions = missions;
    }

    public List<IMission> Missions { get; set; }

    public override string ToString()
    {
        StringBuilder sb=new StringBuilder();
        sb.Append(Environment.NewLine+"Missions:");
        foreach (var mission in this.Missions)
        {
            sb.Append(Environment.NewLine+" "+mission);
        }
        return base.ToString()+sb;
    }
}