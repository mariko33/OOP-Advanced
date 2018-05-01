public class Private:Soldier,IPrivate
{
    public Private(int id, string fistName, string lastName, double salary) : base(id, fistName, lastName)
    {
        this.Salary = salary;
    }

    public double Salary { get; set; }

    public override string ToString()
    {
        return base.ToString()+$"Salary: {this.Salary:f2}";
    }

    public int GetId()
    {
        return this.Id;
    }
}
