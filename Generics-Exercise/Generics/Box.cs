
    using System;

public class Box<T>
    where T:IComparable<T>
    {

        public Box(T storedValue)
        {
            this.StoredValue = storedValue;
        }
        
        public T StoredValue { get; }
    
        public override string ToString()
        {
            return $"{this.StoredValue.GetType().FullName}: {this.StoredValue}";
        }
    }
