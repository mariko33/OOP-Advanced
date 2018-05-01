
using System.Collections.Generic;

public class PersonEqualy : IEqualityComparer<Person>
{
    public bool Equals(Person x, Person y)
    {
        return x.Name == y.Name && x.Age == y.Age;
    }

    public int GetHashCode(Person obj)
    {
        return obj.Name.GetHashCode();
    }
}
