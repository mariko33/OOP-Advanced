
using System.Collections.Generic;
public class ComparePerson : IComparer<Person>
{
    public int Compare(Person x, Person y)
    {
        if (x.Name != y.Name) return x.Name.CompareTo(y.Name);
        if (x.Age != y.Age) return x.Age.CompareTo(y.Age);

        return 0;
    }
}
