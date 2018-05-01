using System;

namespace CustomDatabaseProject
{
    public class Person
    {
        public Person(string username, long id)
        {
            this.Username = username;
            this.Id = id;
        }
        public string Username { get; private set; }
        public long Id { get; private set; }

        public override bool Equals(object obj)
        {
            Person other = (Person) obj;
            if (other == null) return false;
            if (this.Id == other.Id && this.Username == other.Username) return true;

            return false;
        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode() ^ this.Username.GetHashCode() ^ 23;
        }
    }
}