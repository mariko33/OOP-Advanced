using System;
using System.Linq;

namespace CustomDatabaseProject
{
    public class CustomDatabaseExtended
    {
        private const int Capacity = 16;

        private readonly Person[] data;

        private int currentIndex;

        public CustomDatabaseExtended(params Person[] elements)
        {
            this.data = new Person[Capacity];
            if (elements.Length > Capacity) throw new InvalidOperationException("The database capacity should be 16");
            this.currentIndex = 0;

            foreach (var element in elements) this.Add(element);

        }

        public void Add(Person element)
        {
            if (this.currentIndex >= 16) throw new InvalidOperationException("Database is full!");
            this.data[this.currentIndex] = element;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0) throw new InvalidOperationException("Database is empty!");
            this.currentIndex--;
            this.data[this.currentIndex] = default(Person);

        }

        public Person[] Fetch()
        {
            var arr = new Person[this.currentIndex];

            for (int i = 0; i < this.currentIndex; i++) arr[i] = this.data[i];
            return arr;
        }

        public Person FindByUserName(string username)
        {
            if(string.IsNullOrEmpty(username))throw new ArgumentException("Username cannot be null");
            
            Person person = this.data.FirstOrDefault(p => p.Username == username);
            if(person==null)throw new InvalidOperationException("There is no person with given username");

            return person;

        }


        public Person FindById(int id)
        {
            if(id<0)throw new ArgumentException("Id cannot be negtative number");

            Person person = this.data.FirstOrDefault(p => p.Id == id);
            if(person==null)throw new InvalidOperationException("There is no person with given Id");

            return person;
        }
    }
}