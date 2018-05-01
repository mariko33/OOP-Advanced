using System;
using System.Collections.Generic;
using System.Text;

public class LeutenantGeneral:Private,ILeutenantGeneral
{
    public LeutenantGeneral(int id, string fistName, string lastName, double salary,List<ISoldier>privates) : base(id, fistName, lastName, salary)
    {
        this.Privates = privates;
    }
    

    public List<ISoldier> Privates { get; set; }

    public override string ToString()
    {
        StringBuilder sb=new StringBuilder();
        sb.Append("Privates:");
        foreach (var privPrivate in this.Privates)
        {
            sb.Append(Environment.NewLine+privPrivate);
        }
        return base.ToString() + Environment.NewLine + sb;
    }
}
