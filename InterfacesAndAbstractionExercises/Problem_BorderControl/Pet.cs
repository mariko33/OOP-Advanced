public class Pet:IBirthdate
{
    private string name;

    public Pet(string name, string birthdate)
    {
        this.name = name;
        this.Birthdate = birthdate;
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
}
