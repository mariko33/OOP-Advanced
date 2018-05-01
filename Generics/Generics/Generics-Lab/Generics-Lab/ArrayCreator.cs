
    using System.Runtime.InteropServices.ComTypes;

public static class ArrayCreator
    {
        public static T[] Create<T>(int length, T item)
        {
            T[]result=new T[length];
            result[0] = item;
            return result;
        }
    }
