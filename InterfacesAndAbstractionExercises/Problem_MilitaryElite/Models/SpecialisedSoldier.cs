using System;

public class SpecialisedSoldier:Private,ISpecialisedSoldier
{
    private string corp;
    public SpecialisedSoldier(int id, string fistName, string lastName, double salary,string corp) : base(id, fistName, lastName, salary)
    {
        this.Corp = corp;
    }

    public string Corp
    {
        get
        {
            return this.corp;
        }
        private set
        {
            if (value!= "Airforces"&&value!= "Marines")
            {
                throw new ArgumentException("Invalid corps");
                  
            }
            this.corp = value;
        }
    }

    public override string ToString()
    {
        return base.ToString() + Environment.NewLine + $"Corps: {this.Corp}";
    }
}
