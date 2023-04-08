namespace PropertyRenting.Domain.ValueObjects.Owner;

public class OwnerName : ValueObject
{
    public string Value { get; }
    private OwnerName(string value) => Value = value;
    public static ErrorOr<OwnerName> Create(string value)
    {
        if (string.IsNullOrWhiteSpace(value))
            return Errors.Errors.Owner.EmptyName;

        return new OwnerName(value);
    }
    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}
