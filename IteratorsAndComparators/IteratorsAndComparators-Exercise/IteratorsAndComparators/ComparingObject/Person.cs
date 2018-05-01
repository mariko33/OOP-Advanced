using System;

public class Person:IComparable<Person>
{
    public Person(string name, int age, string town)
    {
        this.Name = name;
        this.Age = age;
        this.Town = town;
    }
    
    public string Name { get; private set; }
    public int Age { get; private set; }
    public string Town { get; private set; }
    
    public int CompareTo(Person otherPerson)
    {
        if (this.Name!=otherPerson.Name)return this.Name.CompareTo(otherPerson.Name);
        if (this.Age != otherPerson.Age) return this.Age.CompareTo(otherPerson.Age);
        if (this.Town!=otherPerson.Town) return this.Town.CompareTo(otherPerson.Town);

        return 0;
    }
}
