using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeManagement.Domain.Common.BaseTypes
{
    public abstract class ValueObject<T>  where T : notnull
    {
        public T Value { get;  }

        public ValueObject()
        {
            
        }
        protected ValueObject(T value)
        {
            Value = value;
        }        
        public override string ToString() => Value.ToString();
        public override bool Equals(object? obj)
        {
            if (obj is null || !(obj is ValueObject<T>))
                return false;
            if (obj == this)
                return true;
            return Value.Equals(((ValueObject<T>)obj).Value);
        }
        public override int GetHashCode() => Value.GetHashCode();
    }
}