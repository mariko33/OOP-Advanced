using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class CustomStack<T> : IEnumerable<T>
{
    public CustomStack()
    {
        this.Elements=new List<T>();
    }
    
    public IList<T> Elements { get; set; }

    public void Push(params T[] args)
    {
        foreach (var arg in args)
        {
            this.Elements.Add(arg);
        }
    }

    public void Pop()
    {
        if(this.Elements.Count==0)throw new ArgumentException("No elements");
        T lastElement = this.Elements.Last();
        this.Elements.Remove(lastElement);

    }
    
    public IEnumerator<T> GetEnumerator()
    {
        for (int i = (this.Elements.Count-1); i >= 0; i--)
        {
            yield return this.Elements[i];
        }
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
