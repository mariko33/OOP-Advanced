
using System.Collections.Generic;
public class PersonComparerByAge : IComparer<Person>
{
    public int Compare(Person first, Person second)
    {
        return first.Age - second.Age;
    }
}
