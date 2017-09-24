public interface IBirthdate
{
    string Birthdate { get; }
    
    bool IsBirthYear(string year);
    string GetBirthdate();
}
