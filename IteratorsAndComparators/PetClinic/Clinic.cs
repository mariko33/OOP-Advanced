using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class Clinic
{
    private int numbersOfRooms;
    //private Dictionary<int, Pet> pets;
    private EnumeratorAccommodation<int> accommodation;
    private ReleasePet<int> releasing;
    private List<int> numbers;

    public Clinic(string name, int numbersOfRoom)
    {
        this.Name = name;
        this.NumbersOfRooms = numbersOfRoom;

        this.numbers = new List<int>();

        for (int i = 1; i <= this.NumbersOfRooms; i++)
        {
            numbers.Add(i);
        }

        this.accommodation = new EnumeratorAccommodation<int>(numbers);
        this.releasing = new ReleasePet<int>(numbers);

        this.Pets = this.CreatePets();


    }

    public string Name { get; private set; }

    public int NumbersOfRooms
    {
        get => this.numbersOfRooms;
        private set
        {
            if (value % 2 == 0)
            {
                throw new ArgumentException("Invalid Operation!");
            }

            this.numbersOfRooms = value;
        }
    }

    //public Dictionary<int, Pet> Pets
    //{
    //    get
    //    {
    //        foreach (var a in accommodation)
    //        {
    //            this.pets.Add(a, null);
    //        }

    //        return this.pets;
    //    }
    //    private set { this.pets = value; }
    //}

    public Dictionary<int, Pet> Pets { get; private set; }

    public Dictionary<int, Pet> CreatePets()
    {
        Dictionary<int, Pet> currPets = new Dictionary<int, Pet>();
        foreach (var a in accommodation)
        {
            currPets.Add(a, null);
        }

        return currPets;
    }

    public bool AddPet(Pet pet)
    {
        int notOccupiedRoom = this.Pets.FirstOrDefault(kv => kv.Value == null).Key;
        if (notOccupiedRoom == 0) return false;

        this.Pets[notOccupiedRoom] = pet;
        return true;


    }


    public bool ReleasingPet()
    {

        foreach (var r in releasing)
        {
            if (this.Pets[r] != null)
            {
                this.Pets[r] = null;
                return true;
            }
        }


        return false;
    }

    public string PrintRoom(int roomNumber)
    {
        if (this.Pets[roomNumber] != null) return this.Pets[roomNumber].ToString();

        return "Room empty";
    }

    public bool HasEmptyRoom()
    {
        if (this.Pets.Any(kv => kv.Value == null)) return true;

        return false;
    }


    public override string ToString()
    {
        StringBuilder sb = new StringBuilder();

        foreach (var kv in this.Pets.OrderBy(kv => kv.Key))
        {
            if (kv.Value == null) sb.AppendLine("Room empty");
            else sb.AppendLine(kv.Value.ToString());
        }

        return sb.ToString().TrimEnd();
    }

    private class EnumeratorAccommodation<T> : IEnumerable<T>
    {
        private List<T> numbers;

        public EnumeratorAccommodation(List<T> numbers)
        {
            this.numbers = numbers;
        }

        public IEnumerator<T> GetEnumerator()
        {

            int middleCount = (this.numbers.Count / 2);

            var leftList = this.numbers.Take(middleCount).ToList();
            var rightList = this.numbers.Skip(middleCount + 1).ToList();
            leftList.Reverse();



            yield return this.numbers[middleCount];

            for (int i = 0; i < leftList.Count; i++)
            {
                yield return leftList[i];
                yield return rightList[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }

    private class ReleasePet<T> : IEnumerable<T>
    {
        private List<T> numbers;

        public ReleasePet(List<T> numbers)
        {
            this.numbers = numbers;
        }


        public IEnumerator<T> GetEnumerator()
        {
            int middleCount = (this.numbers.Count / 2);

            var leftList = this.numbers.Take(middleCount).ToList();
            var rightList = this.numbers.Skip(middleCount+1).ToList();

            yield return this.numbers[middleCount];

            var result = rightList.Concat(leftList).ToList();

            for (int i = 0; i < result.Count; i++)
            {
                yield return result[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

    }

}


