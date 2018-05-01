
using System.Collections;
using System.Collections.Generic;
using System.Linq;

public class Lake<T> : IEnumerable<T>
{

    public Lake(params T[] args)
    {
        this.Stones = args.ToList();
    }
    
    public IList<T> Stones { get; }
    
    public IEnumerator<T> GetEnumerator()
    {
        List<T> evenIndexList = new List<T>();
        List<T> oddList = new List<T>();
        for (int i = 0; i < this.Stones.Count; i++)
        {
            if (i % 2 == 0) evenIndexList.Add(this.Stones[i]);
            else oddList.Add(this.Stones[i]);
        }
        oddList.Reverse();

        var result = evenIndexList.Concat(oddList).ToList();
        for (int i = 0; i < result.Count(); i++)
        {
            yield return result[i];
        }

    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}
