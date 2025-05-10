namespace EmployeeManagement.UI.Models.BaseTypes
{
    public abstract class ValueObject<T>  where T : notnull
    {
        public T Value { get;  }

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