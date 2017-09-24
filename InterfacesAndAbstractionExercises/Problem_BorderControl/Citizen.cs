public class Citizen:Society,IBirthdate,IBuyer
{
    private int age;
    public Citizen(string name,int age, string id, string birthdate) : base(name, id)
    {
        this.age = age;
        this.Birthdate = birthdate;
        this.Food = 0;
    }

    public string Birthdate { get; private set; }
    public bool IsBirthYear(string year)
    {
        return this.Birthdate.EndsWith(year);
    }

    public string GetBirthdate()
    {
        return this.Birthdate;
    }

    public int Food { get; private set; }
    public void BuyFood()
    {
        this.Food += 10;
    }
}
