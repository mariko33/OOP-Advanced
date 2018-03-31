using System;
using System.Collections.Generic;

class StartUp
{
    static void Main()
    {
        IComparer<Person> comparerByName = new PersonComparerName();
        IComparer<Person> comparerByAge = new PersonComparerByAge();

        SortedSet<Person> sortedPeopleByName = new SortedSet<Person>(comparerByName);
        SortedSet<Person> sortedPeopleByAge = new SortedSet<Person>(comparerByAge);

        int count = int.Parse(Console.ReadLine());

        for (int i = 0; i < count; i++)
        {
            var inputArgs = Console.ReadLine().Split();
            string name = inputArgs[0];
            int age = int.Parse(inputArgs[1]);
            Person person = new Person(name, age);
            sortedPeopleByName.Add(person);
            sortedPeopleByAge.Add(person);
        }

        foreach (var pName in sortedPeopleByName)
        {
            Console.WriteLine($"{pName.Name} {pName.Age}");
        }

        foreach (var pAge in sortedPeopleByAge)
        {
            Console.WriteLine($"{pAge.Name} {pAge.Age}");
        }
    }
}

