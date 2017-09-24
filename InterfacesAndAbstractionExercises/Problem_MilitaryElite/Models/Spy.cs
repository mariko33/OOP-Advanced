using System;

public class Spy:Soldier,ISpy
{
    public Spy(int id, string fistName, string lastName,int codeNumber) : base(id, fistName, lastName)
    {
        this.CodeNumber = codeNumber;
    }

    public int CodeNumber { get; set; }

    public override string ToString()
    {
        return base.ToString() + $"{Environment.NewLine}Code Number: {this.CodeNumber}";
    }
}
