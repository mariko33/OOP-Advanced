using System;
using System.Collections.Generic;
using System.Linq;


class StartUp
{
    static void Main()
    {
        List<Person>people=new List<Person>();

        string input;
        while ((input=Console.ReadLine())!="END")
        {
            var args = input.Split(new []{" "},StringSplitOptions.RemoveEmptyEntries);
            string name = args[0];
            int age = int.Parse(args[1]);
            string town = args[2];
            Person person=new Person(name,age,town);
            people.Add(person);
        }

        int indexPerson = int.Parse(Console.ReadLine());
        Person targetPerson = people[indexPerson - 1];
        people.Remove(targetPerson);
        
        int numberOfEqualPeople = people.Where(p => p.CompareTo(targetPerson)==0).Count();
        int numberOfNonEqualPeople = people.Where(p => p.CompareTo(targetPerson)!=0).Count();

        if(numberOfEqualPeople==0) Console.WriteLine("No matches");
       else Console.WriteLine($"{numberOfEqualPeople+1} {numberOfNonEqualPeople} {people.Count+1}");
    }
}

