using System;
using System.Collections.Generic;
using System.Linq;

namespace CustomDatabaseProject
{
    public class CustomDatabase
    {
        private const int Capacity = 16;

        private readonly int[] data;

        private int currentIndex;

        public CustomDatabase(params int[] elements)
        {
            this.data=new int[Capacity];
            if(elements.Length>Capacity)throw new InvalidOperationException("The database capacity should be 16");
            this.currentIndex = 0;

            foreach (var element in elements) this.Add(element);

        }

        public void Add(int element)
        {
            if (this.currentIndex >= 16) throw new InvalidOperationException("Database is full!");
            this.data[this.currentIndex] = element;
            this.currentIndex++;
        }

        public void Remove()
        {
            if (this.currentIndex == 0) throw new InvalidOperationException("Database is empty!");
            this.currentIndex--;
            this.data[this.currentIndex] = default(int);
            
        }

        public int[] Fetch()
        {
            var arr = new int[this.currentIndex];

            for (int i = 0; i < this.currentIndex; i++) arr[i] = this.data[i];
            return arr;
        }
        
    }
}