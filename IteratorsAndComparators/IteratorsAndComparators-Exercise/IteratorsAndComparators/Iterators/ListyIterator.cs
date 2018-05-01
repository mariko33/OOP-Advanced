
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class ListyIterator<T>:IEnumerable<T>
{
    private int currIndex;

    public ListyIterator(IEnumerable<T> inputCollection)
    {
        this.InputCollection = new List<T>(inputCollection);
        currIndex = 0;
    }

    public ListyIterator()
    :this(Enumerable.Empty<T>())
    {
        
    }

    public List<T> InputCollection { get; set; }

  

    public bool HasNext()
    {
        if (this.currIndex == this.InputCollection.Count - 1) return false;

        return true;
    }

    public bool Move()
    {
        if (this.HasNext())
        {
            this.currIndex++;
            return true;
        }

        return false;
    }

    public void Print()
    {
        if(this.InputCollection.Count==0) throw new InvalidOperationException("Invalid Operation!");
        Console.WriteLine(this.InputCollection[this.currIndex]);
    }

    public IEnumerator<T> GetEnumerator()
    {
        for (int i = 0; i < this.InputCollection.Count; i++)
        {
            yield return this.InputCollection[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }

   
}
