
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Linq;

public class CustomList<T>
    where T:IComparable<T>,IEnumerable
{
    private List<T> elements;

    public CustomList()
    {
        elements=new List<T>();
    }

    public void Add(T element)
    {
        this.elements.Add(element);
    }
    
    public void Remove(int index)
    {
        T element = this.elements[index];
        this.elements.RemoveAt(index);
        //return element;
    }

    public bool Contains(T element)
    {
        return this.elements.Contains(element);
    }

    public void Swap(int index1, int index2)
    {
        var firstElement = this.elements[index1];
        var secondElement = this.elements[index2];
        this.elements[index1] = secondElement;
        this.elements[index2] = firstElement;
    }

    public int CountGreaterThan(T element)
    {
        int count = this.elements.Where(e => e.CompareTo(element) > 0).ToList().Count;
        return count;
    }

    public int CountLowerThan(T element)
    {
        int count = this.elements.Where(e => e.CompareTo(element) < 0).ToList().Count;
        return count;
    }
    
    public T Max()
    {
        return this.elements.FirstOrDefault(e => this.CountGreaterThan(e) == 0);
    }

    public T Min()
    {
        return this.elements.FirstOrDefault(e => this.CountLowerThan(e) == 0);
    }

    public void Print()
    {
        Console.WriteLine(string.Join(Environment.NewLine,this.elements));
    }

    public void Sort()
    {
       this.elements=Sorter<T>.SortList(this.elements);
    }

    
}
