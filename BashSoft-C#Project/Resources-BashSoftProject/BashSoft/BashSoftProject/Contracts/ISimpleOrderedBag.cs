using System;
using System.Collections.Generic;

namespace BashSoftProject.Contracts
{
    public interface ISimpleOrderedBag<T>:IEnumerable<T> where T:IComparable<T>
    {
        bool Remove(T element);
        int Capacity { get; }
        int Size { get; }
        void Add(T element);
        void AddAll(ICollection<T> collection);
        string JoinWhith(string joiner);
    }
}