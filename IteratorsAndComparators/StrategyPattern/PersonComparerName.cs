using System.Collections.Generic;
public class PersonComparerName : IComparer<Person>
{
    public int Compare(Person first, Person second)
    {
        int result = first.Name.Length - second.Name.Length;
        if (result == 0)
        {
            result = char.ToLower(first.Name[0]).CompareTo(char.ToLower(second.Name[0]));
        }

        return result;
    }
}
