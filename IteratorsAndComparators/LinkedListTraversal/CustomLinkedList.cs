using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;


public class CustomLinkedList<T> : IEnumerable<T>
{
    public CustomLinkedList()
    {
        CustomCollection = new Collection<T>();
    }
    public ICollection<T> CustomCollection { get; private set; }

    public int Count => this.CustomCollection.Count(); 
    
    public IEnumerator<T> GetEnumerator()
    {
        foreach (var c in this.CustomCollection)
        {
            yield return c;
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

    public void Add(T element)
    {
        this.CustomCollection.Add(element);
    }

    public void Remove(T element)
    {
        this.CustomCollection.Remove(element);
    }
}
