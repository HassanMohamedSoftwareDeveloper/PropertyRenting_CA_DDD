namespace PropertyRenting.Domain.Primitives
{
    public abstract class ValueObject : IEquatable<ValueObject>
    {
        public abstract IEnumerable<object> GetAtomicValues();

        public override bool Equals(object obj)
            => obj is ValueObject other && ValuesAreEqual(other);

        public override int GetHashCode()
            => GetAtomicValues()
                .Aggregate(default(int),
                HashCode.Combine);

        private bool ValuesAreEqual(ValueObject other)
            => GetAtomicValues().SequenceEqual(other.GetAtomicValues());

        public bool Equals(ValueObject other)
            => other is not null && ValuesAreEqual(other);

        public static bool operator ==(ValueObject value, ValueObject other)
        {
            if (value is null && other is null) return true;

            if ((value is null && other is not null) || (value is not null && other is null)) return false;

            return value.ValuesAreEqual(other);
        }
        public static bool operator !=(ValueObject value, ValueObject other)
        {
            return !(value == other);
        }
    }
}
