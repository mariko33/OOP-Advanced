using System;
using System.Collections.Generic;


class StartUp
    {
        static void Main()
        {
            ComparePerson comparePerson=new ComparePerson();
            SortedSet<Person>sortedPeople=new SortedSet<Person>(comparePerson);
            HashSet<Person>uniquePeople=new HashSet<Person>(new PersonEqualy());
            
            int count = int.Parse(Console.ReadLine());

            for (int i = 0; i < count; i++)
            {
                var inputArgs = Console.ReadLine().Split();
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);
                
                Person person=new Person(name,age);
                
                sortedPeople.Add(person);
                uniquePeople.Add(person);

            }

            Console.WriteLine(sortedPeople.Count);
            Console.WriteLine(uniquePeople.Count);
        }
    }

