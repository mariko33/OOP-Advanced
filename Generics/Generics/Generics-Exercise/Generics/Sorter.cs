
    using System;
    using System.Collections.Generic;
    using System.Linq;

public static class Sorter<T>
    where T:IComparable<T>
    {
        public static List<T> SortList(List<T>elements)
        {
            return elements.OrderBy(e=>e).ToList();
        }
    }
